﻿using IHM.MVVM.ViewModels;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        static StartupWindow startup;
        public StartupWindow()
        {
            InitializeComponent();
            startup = this;
        }

        public static StartupWindow getStartup()
        {
            return startup;
        }
    }
}
