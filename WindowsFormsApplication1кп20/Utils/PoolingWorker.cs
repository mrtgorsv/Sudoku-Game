using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace WindowsFormsApplication1кп20.Utils
{
    internal class PoolingWorker : IDisposable
    {
        #region Constructor & properties

        private readonly int _dueTime;
        private readonly int _period;
        private readonly object _lock = new object();

        private Action _action;
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private int _refreshCount;
        private int _paused;
        private Task _bgTask;
        private Timer _stateTimer;

        public PoolingWorker(int dueTime, int period)
        {
            _dueTime = dueTime;
            _period = period;
            _paused = 0;
        }

        #endregion

        public bool IsPaused
        {
            get => _paused != 0;
            set
            {
                if (value)
                {
                    Interlocked.Exchange(ref _paused, 1);
                }
                else
                {
                    Interlocked.Exchange(ref _paused, 0);
                }
            }
        }

        public void ForceDeferredDataLoad()
        {
            Interlocked.Increment(ref _refreshCount);
        }

        public void ResetDeferredDataLoad()
        {
            Interlocked.Exchange(ref _refreshCount, 0);
        }

        public void StartPooling(Action action)
        {
            lock (_lock)
            {
                if (_action != null) return;

                _action = action;

                _stateTimer = new Timer(BgJob, null, _dueTime, _period);
            }
        }

        private void BgJob(object state)
        {
            if (_refreshCount < 1)
                return;

            if (IsPaused)
            {
                return;
            }
            if (_bgTask != null && _bgTask.Status == TaskStatus.Running)
                return;

            ResetDeferredDataLoad();

            if (_action == null) return;

            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            _bgTask = Task.Factory.StartNew(() =>
            {
                var cThread = Thread.CurrentThread;

                var cultureInfo = Application.CurrentCulture;
                cThread.CurrentCulture = cultureInfo;
                cThread.CurrentUICulture = cultureInfo;

                using (_cancellationToken.Register(() => { cThread.Abort(); }))
                {
                    _action();
                }
            }, _cancellationToken);
        }


        public void Dispose()
        {
            if (_bgTask != null && _cancellationToken.CanBeCanceled)
                _cancellationTokenSource.Cancel();

            _stateTimer?.Dispose();
        }
    }
}