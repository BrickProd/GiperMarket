using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Barebuh.Models;
using Prism.Mvvm;

namespace Barebuh.ViewModels
{
    [Export]
    public class ShellViewModel : BindableBase
    {
        public string UserStatus { get; set; }
        public string CurrentUser { get; set; }

        //[ImportingConstructor]
        //public ShellViewModel(string status, User user)
        //{
        //    UserStatus = status;
        //    CurrentUser = user;
        //}

        [ImportingConstructor]
        public ShellViewModel()
        {
            UserStatus = "Salam ";

            CustomPrincipal customPrincipal = Thread.CurrentPrincipal as CustomPrincipal;
            UserStatus += customPrincipal.Identity.Name;

        }
    }
}
