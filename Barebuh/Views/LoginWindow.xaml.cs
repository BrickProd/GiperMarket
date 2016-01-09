using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Barebuh.ViewModels;

namespace Barebuh.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>

    public interface IView
    {
        IViewModel ViewModel { get; set; }
        void Show();
    }
    public partial class LoginWindow : Window, IView
    {
        public LoginWindow(LoginViewModel viewModel)
        {
            ViewModel = viewModel;
            InitializeComponent();
        }

        public IViewModel ViewModel
        {
            get { return DataContext as IViewModel;}
            set { DataContext = value; }
        }
    }
}
