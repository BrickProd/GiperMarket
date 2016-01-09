using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Barebuh.Models;
using Barebuh.ViewModels;
using Barebuh.Views;

namespace Barebuh
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            CustomPrincipal customPrincipal = new CustomPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(customPrincipal);

            base.OnStartup(e);

            LoginViewModel viewModel = new LoginViewModel(new AuthenticationService());
            IView loginWindow = new LoginWindow(viewModel);
            loginWindow.Show();
        }
    }
}
