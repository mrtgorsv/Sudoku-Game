using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Events;
using WindowsFormsApplication1кп20.Extensions;
using WindowsFormsApplication1кп20.Utils;
using WindowsFormsApplication1кп20.Utils.Sudoku;

namespace WindowsFormsApplication1кп20.Presenters
{
    public class GamePresenter : PresenterBase
    {
        private int _timerTick = 1;
        private TimeSpan _elapsedTime = TimeSpan.Zero;
        private readonly Timer _timer = new Timer();

        private Board _gameBoard;
        private Board _solutionBoard;

        private readonly PoolingWorker _gameGenerationWorker = new PoolingWorker(100, 2000);

        public event EventHandler<EventArgs> GameCreated;

        public event TimerTickEventHandler TimerTick;
        public delegate void TimerTickEventHandler(object sender, TimerTickEventArgs args);

        public TimeSpan ElapsedTime => _elapsedTime;
        public string ElapsedTimeString => _elapsedTime.ToString("T");

        public Board GameBoard
        {
            get { return _gameBoard; }
            set { _gameBoard = value; }
        }

        public GamePresenter(ISecurityManager securityManager) : base(securityManager)
        {
            _timer.Interval = Convert.ToInt32(TimeSpan.FromSeconds(_timerTick).TotalMilliseconds);
            _timer.Tick += OnTimerTick;

            _gameGenerationWorker.StartPooling(GenerateGameField);

            _gameGenerationWorker.ForceDeferredDataLoad();
        }

        public void StartGame()
        {
            _timer.Start();
        }

        public void StopGame()
        {
            _timer.Stop();
        }

        protected override void OnDispose()
        {
            base.OnDispose();
            _gameGenerationWorker.Dispose();
            _timer.Dispose();
        }

        public bool IsValid(int x, int y)
        {
            if (_gameBoard.GetNumber(x, y) == 0)
            {
                return false;
            }
            return _gameBoard.GetNumber(x, y) == _solutionBoard.GetNumber(x, y);
        }

        private void GenerateGameField()
        {
            try
            {
                BoardGenerator boardGenerator = new BoardGenerator();
                boardGenerator.GenerateSolutionBoard();
                boardGenerator.GenerateGameBoard();
                _gameBoard = boardGenerator.GetGameBoard();
                _solutionBoard = boardGenerator.GetSolutionBoard();

                OnGameCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        private void OnGameCreated()
        {
            GameCreated.SafeRaise(this, EventArgs.Empty);
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            _elapsedTime = _elapsedTime.Add(TimeSpan.FromSeconds(_timerTick));
            RaiseTimerTickEvent();
        }

        private void RaiseTimerTickEvent()
        {
            TimerTick?.Invoke(this, new TimerTickEventArgs(ElapsedTimeString));
        }
    }
}
