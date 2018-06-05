using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class RegisterView : Form
    {
        public RegisterPresenter CurrentPresenter { get; set; }

        public RegisterView()
        {
            InitializeComponent();
            InitializeListeners();
            CurrentPresenter = IocKernel.Get<RegisterPresenter>();
            Text = Resources.MainTitle;
        }

        private void InitializeListeners()
        {
            ContinueButton.Click += OnContinueButtonClicked;
            RulesButton.Click += OnRulesButtonClicked;
            ExitButton.Click += OnExitButtonClicked;
            OkButton.Click += OnContinueButtonClicked;
            ContinueButton.Click += OnContinueButtonClicked;
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

        private void OnContinueButtonClicked(object sender, EventArgs e)
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
            game.Show(this);
        }

        private void OnGameClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}