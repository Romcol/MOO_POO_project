using IHM.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IHM.MVVM.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static StartupWindow startup;
        static GameWindow game;
        public MainWindow()
        {
            InitializeComponent();
            startup = new StartupWindow();
            startup.DataContext = new StartupViewModel(); // couplage de la vue (fenêtre principale) avec le VueModel (MainViewModel)
            startup.Show();
        }

        public static void launchGame()
        {
            game = new GameWindow();
            game.DataContext = new GameViewModel();
            startup.Hide();
            game.Show();
        }
    }
}