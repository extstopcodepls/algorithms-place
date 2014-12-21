using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using Ext.Algorithms.Desktop.ViewModels;

namespace Ext.Algorithms.Desktop
{
    public class AppBootstraper : BootstrapperBase
    {
        public AppBootstraper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();

            base.OnStartup(sender, e);
        }
    }
}
