using System;
using System.Windows.Forms;
using WindowsFormsApplication1кп20.Properties;
using WindowsFormsApplication1кп20.Utils.IoC;
using WindowsFormsApplication1кп20.Views;

namespace WindowsFormsApplication1кп20
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeContainer();
            var mainView = new RegisterView();
            Application.Run(mainView);
        }

        private static void InitializeContainer()
        {
            IocKernel.Initialize(new IocConfiguration());
        }
    }
}
