using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Barebuh.Models;
using Barebuh.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace Barebuh.ViewModels
{
    public interface IViewModel { }
    public class LoginViewModel : BindableBase, IViewModel
    {
        private readonly IAuthenticationService _authenticationService;
        private string _username;
        private string _status;
        private DelegateCommand<object> _loginCommand;


        public LoginViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _loginCommand = new DelegateCommand<object>(Login, CanLogin);
        }


        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged(); }
        }

        public string AuthenticatedUser
        {
            get
            {
                if(IsAuthenticated)
                    return String.Format("вошёл {0}. {1}", Thread.CurrentPrincipal.Identity.Name,
                        Thread.CurrentPrincipal.IsInRole("Administrators") ? "Администратор" : "Лох пидр");
                return "Мутный чепуш";
            }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value;OnPropertyChanged(); }
        }

        public bool IsAuthenticated
        {
            get { return Thread.CurrentPrincipal.Identity.IsAuthenticated; }
        }


        public DelegateCommand<object> LoginCommand { get { return _loginCommand; } }



        private void Login(object param)
        {
            PasswordBox passwordBox = param as PasswordBox;
            string clearTextPassword = passwordBox.Password;
            try
            {
                User user = _authenticationService.AuthenticateUser(Username, clearTextPassword);
                CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
                if (customPrincipal == null)
                    throw new ArgumentException("Ошибка 1");

                customPrincipal.Identity = new CustomIdentity(user.Username, user.Email, user.Roles);

                OnPropertyChanged("AuthenticatedUser");
                OnPropertyChanged("IsAuthenticated");
                _loginCommand.RaiseCanExecuteChanged();




                Username = String.Empty;
                passwordBox.Password = String.Empty;

                Window loginWindow = Window.GetWindow(passwordBox);



                //ShellViewModel viewModel = new ShellViewModel(AuthenticatedUser, user);
                //IView view = new Shell(viewModel);
                //view.Show();

                Bootstrapper bootstrapper = new Bootstrapper();
                bootstrapper.Run();

                loginWindow.Close();
            }
            catch (UnauthorizedAccessException)
            {
                Status = "Ошибка входа";
            }
            catch (Exception ex)
            {
                Status = $"Ошибка: {ex.Message}";
            }
        }

        private bool CanLogin(object param)
        {
            return !IsAuthenticated;
        }

        private void ShowView(Window loginWindow)
        {
            try
            {
                
            }
            catch (Exception)
            {
                Status = "ВЫ не авторизованы";
            }
        }
    }
}
