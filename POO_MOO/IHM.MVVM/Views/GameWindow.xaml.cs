using API;
using IHM.MVVM.ViewModels;
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

namespace IHM.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        static GameWindow gameWin;
        static StartupWindow startup;
        public GameWindow()
        {
            InitializeComponent();
            gameWin = this;
        }
        public static void goToStartup()
        {
            startup = new StartupWindow();
            startup.DataContext = new StartupViewModel(); // couplage de la vue (fenêtre principale) avec le VueModel (MainViewModel)
            gameWin.Hide();
            startup.Show();
        }
    }
}
