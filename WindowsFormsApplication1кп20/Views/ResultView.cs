using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Presenters;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.IoC;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class ResultView : Form
    {
        protected ResultPresenter CurrentPresenter { get; set; }

        public ResultView()
        {
            CurrentPresenter = IocKernel.Get<ResultPresenter>();
            InitializeComponent();
            InitializeListeners();
        }

        private void InitializeListeners()
        {
            MainMenuButton.Click += OnMainMenuButtonClicked;
        }

        private void OnMainMenuButtonClicked(object sender, EventArgs e)
        {
            Close();
        }

        public void AddResult(TimeSpan elapsedTime)
        {
            CurrentPresenter.AddResult(elapsedTime);
            UpdateDataSource();
        }

        private void UpdateDataSource()
        {
            ResultListBox.DataSource = null;
            ResultListBox.DataSource = CurrentPresenter.DataSource;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = Resources.MainTitle;
            Icon = Resources.Icon;
        }
    }
}