using IHM.MVVM.ViewModels;
using IHM.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IHM.MVVM
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            window.DataContext = new MainViewModel(); // couplage de la vue (fenêtre principale) avec le VueModel (MainViewModel)
            window.Show();
        }
    }
}
