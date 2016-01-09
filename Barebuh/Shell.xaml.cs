using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Barebuh.ViewModels;
using Barebuh.Views;
using Prism.Modularity;
using Prism.Regions;

namespace Barebuh
{
    /// <summary>
    /// Логика взаимодействия для Shell.xaml
    /// </summary>
    /// 
    /// 
    [Export]
    [PrincipalPermission(SecurityAction.Demand)]
    public partial class Shell : Window
    {

        [Import(AllowRecomposition = false)]
        public IModuleManager ModuleManager;

        [Import(AllowRecomposition = false)]
        public IRegionManager RegionManager;

        public Shell()
        {

            InitializeComponent();
        }

        //public IViewModel ViewModel
        //{
        //    get
        //    {
        //        return DataContext as IViewModel;
        //    }
        //    set { DataContext = value; }
        //}

        [Import]
        public ShellViewModel ViewModel
        {
            set { this.DataContext = value; }
        }
    }
}
