using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class RulesView : Form
    {
        protected RulesPresenter CurrentPresenter { get; set; }

        public RulesView()
        {
            InitializeComponent();
            CurrentPresenter = IocKernel.Get<RulesPresenter>();
            InitializeSource();
            InitializeListeners();
        }

        private void InitializeListeners()
        {
            MainMenuButton.Click += OnExitButtonClicked;
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeSource()
        {
            RulesLabel.Text = CurrentPresenter.Rules;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = Resources.MainTitle;
            Icon = Resources.Icon;
        }
    }
}