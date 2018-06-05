using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Properties;

namespace WindowsFormsApplication1кп20.Views
{
    public partial class ResultView : Form
    {
        public ResultView()
        {
            InitializeComponent();
            Text = Resources.MainTitle;
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
    }
}
