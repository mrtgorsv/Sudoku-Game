using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Events;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class GameView : Form
    {
        protected GamePresenter CurrentPresenter { get; set; }

        public GameView()
        {
            CurrentPresenter = IocKernel.Get<GamePresenter>();
            InitializeComponent();
            InitializeListeners();
        }

        private void OnViewLoad(object sender, EventArgs e)
        {
            Text = Resources.MainTitle;
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            SudokuBoardGridView.ColumnCount = 9;
            SudokuBoardGridView.RowCount = 9;
            for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
            {
                if (i % 3 == 2)
                {
                    SudokuBoardGridView.Columns[i].DividerWidth = 3;
                }

                if (j % 3 == 2) SudokuBoardGridView.Rows[j].DividerHeight = 3;
            }
        }

        private void InitializeListeners()
        {
            Load += OnViewLoad;
            CheckResultButton.Click += OnCheckResultButtonClick;
            CurrentPresenter.TimerTick += OnTimerTick;
            CurrentPresenter.StartGame();
        }

        private void OnTimerTick(object sender, TimerTickEventArgs args)
        {
            TotalTimeLabel.Text = args.ElapsedTime;
        }

        private void OnCheckResultButtonClick(object sender, EventArgs e)
        {
            CurrentPresenter.CheckResult();
        }
    }
}