using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Events;
using WindowsFormsApplication1кп20.Utils;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class GamePresenter : PresenterBase
    {
        private int _timerTick = 1;
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private readonly Timer _timer = new Timer();

        public string ElapsedTime => _elapsedTime.Equals(TimeSpan.Zero) ? string.Empty : _elapsedTime.ToString("T");

        // Событие завершения теста
        public event TimerTickEventHandler TimerTick;
        // Обработчик события завершения теста
        public delegate void TimerTickEventHandler(object sender, TimerTickEventArgs args);

        public GamePresenter(ISecurityManager securityManager) : base(securityManager)
        {
            _timer.Interval = TimeSpan.FromSeconds(_timerTick).Milliseconds;
            _timer.Tick += OnTimerTick;
        }
        // Функция обработки события переключения таймера
        private void OnTimerTick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(_timerTick));
            RaiseTimerTickEvent();
        }

        private void RaiseTimerTickEvent()
        {
            TimerTick?.Invoke(this, new TimerTickEventArgs(ElapsedTime));
        }

        public void StartGame()
        {
            _timer.Start();
        }
    }
}
