using System;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Events;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.EventArgs;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class GameView : Form
    {
        protected GamePresenter CurrentPresenter { get; set; }

        public delegate void GameCompleteEventHandler<T>(object sender, GameCompleteEventArgs args);

        public event GameCompleteEventHandler<GameCompleteEventArgs> GameComplete;

        public GameView()
        {
            CurrentPresenter = IocKernel.Get<GamePresenter>();
            InitializeComponent();
            InitializeListeners();
        }

        private void OnViewLoad(object sender, EventArgs e)
        {
            Text = Resources.MainTitle;
            Icon = Resources.Icon;
            TotalTimeLabel.Text = CurrentPresenter.ElapsedTimeString;
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

                if (j % 3 == 2)
                {
                    SudokuBoardGridView.Rows[j].DividerHeight = 3;
                }

                var cellValue = CurrentPresenter.GameBoard.GetNumber(i, j);
                if (cellValue == 0)
                {
                    continue;
                }
                var cell = SudokuBoardGridView.Rows[i].Cells[j];
                cell.Value = cellValue;
                cell.Style.ForeColor = Color.Blue;
                cell.ReadOnly = true;
            }

            SudokuBoardGridView.EditingControlShowing += OnEditingControlShowing;
        }

        private void InitializeListeners()
        {
            Load += OnViewLoad;
            CheckResultButton.Click += OnCheckResultButtonClick;
            CurrentPresenter.TimerTick += OnTimerTick;
            CurrentPresenter.GameCreated += OnGameCreated;
        }

        private void OnGameCreated(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => OnGameCreated(sender, e)));
            }
            else
            {
                InitializeGrid();
                CheckResultButton.Text = Resources.CheckMessage;
                CheckResultButton.Enabled = true;
                CurrentPresenter.StartGame();
            }
        }

        private void OnTimerTick(object sender, TimerTickEventArgs args)
        {
            TotalTimeLabel.Text = args.ElapsedTime;
        }

        private void OnCheckResultButtonClick(object sender, EventArgs e)
        {
            UpdateGameBoard();
            if (!ValidateGameBoard()) return;

            CurrentPresenter.StopGame();
            RaiseGameComplete();
        }

        private void RaiseGameComplete()
        {
            GameComplete?.Invoke(this, new GameCompleteEventArgs {ElapsedTime = CurrentPresenter.ElapsedTime});
        }

        private bool ValidateGameBoard()
        {
            bool complete = true;
            for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
            {
                var cell = SudokuBoardGridView.Rows[i].Cells[j];
                if (CurrentPresenter.IsValid(i, j))
                {
                    cell.Style.BackColor = Color.White;
                }
                else
                {
                    complete = false;
                    cell.Style.BackColor = Color.Red;
                }
            }
            return complete;
        }

        private void UpdateGameBoard()
        {
            for (int i = 0; i < 9; i++)
            for (int j = 0; j < 9; j++)
            {
                var cell = SudokuBoardGridView.Rows[i].Cells[j];
                CurrentPresenter.GameBoard.SetNumber(i, j, cell.Value == null ? 0 : Convert.ToInt32(cell.Value));
            }
        }

        private void OnEditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.CellStyle.BackColor = Color.White;
            e.Control.KeyPress -= OnEditorKeyPressed;
            if (e.Control is TextBox editor)
            {
                editor.TextChanged -= OnEditorTextChanged;
                editor.KeyPress += OnEditorKeyPressed;
                editor.TextChanged += OnEditorTextChanged;
            }
        }

        private void OnEditorTextChanged(object sender, EventArgs e)
        {
            if (sender is DataGridViewTextBoxEditingControl textBox)
            {
                if (!string.IsNullOrWhiteSpace(textBox.Text))
                {
                    var totalValue = Convert.ToInt32(textBox.Text);
                    if (totalValue > 9)
                    {
                        textBox.Text = null;
                    }
                }
            }
        }

        private void OnEditorKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                var value = (int) Char.GetNumericValue(e.KeyChar);
                if (value < 1)
                {
                    e.Handled = true;
                }
            }
            else if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            CurrentPresenter.Dispose();
        }
    }
}