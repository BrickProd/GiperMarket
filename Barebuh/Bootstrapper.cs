using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Barebuh.ViewModels;
using Barebuh.Views;
using Prism.Mef;
using Prism.Modularity;

namespace Barebuh
{
    public class Bootstrapper : MefBootstrapper
    {
        private ShellViewModel shellViewModel;

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(Bootstrapper).Assembly));
        }

        protected override DependencyObject CreateShell()
        {

            return this.Container.GetExportedValue<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }
    }
}
