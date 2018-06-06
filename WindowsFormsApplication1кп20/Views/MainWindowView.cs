using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.EventArgs;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class MainWindowView : Form
    {
        private ResultView _resultView = new ResultView();

        public MainPresenter CurrentPresenter { get; set; }

        public MainWindowView()
        {
            InitializeComponent();
            InitializeListeners();
            CurrentPresenter = IocKernel.Get<MainPresenter>();
        }

        private void InitializeListeners()
        {
            RulesButton.Click += OnRulesButtonClicked;
            ExitButton.Click += OnExitButtonClicked;
            StartButton.Click += OnStartButtonClicked;
            ResultButton.Click += OnResultButtonClicked;
        }

        private void OnResultButtonClicked(object sender, EventArgs e)
        {
            ShowResultView();
        }


        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnRulesButtonClicked(object sender, EventArgs e)
        {
            ShowRulesView();
        }

        private void ShowRulesView()
        {
            RulesView rules = new RulesView {Text = Resources.MainTitle};

            rules.ShowDialog(this);
        }

        private void OnStartButtonClicked(object sender, EventArgs e)
        {
            ShowGameView();
        }

        private void ShowGameView()
        {
            if (!string.IsNullOrEmpty(NameTextBox.Text))
            {
                CurrentPresenter.SetCurrentUser(NameTextBox.Text);
            }

            Hide();

            GameView game = new GameView {Text = Resources.MainTitle};
            game.Closed += OnGameClosed;
            game.GameComplete += OnGameCompleted;
            game.Show(this);
        }

        private void OnGameCompleted(object sender, GameCompleteEventArgs args)
        {
            (sender as GameView)?.Close();
            Show();
            _resultView.AddResult(args.ElapsedTime);
            ShowResultView();
        }
        private void ShowResultView()
        {
            _resultView.ShowDialog(this);
        }

        private void OnGameClosed(object sender, EventArgs e)
        {
            Show();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = Resources.MainTitle;
            Icon = Resources.Icon;
        }
    }
}