﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for Authorization_Page.xaml
    /// </summary>
    public partial class Authorization_Page : Page
    {
        public Window win = new Window();

        public Authorization_Page()
        {
            InitializeComponent();
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Min_but_Click(object sender, RoutedEventArgs e)
        {
            win.WindowState = WindowState.Minimized;
        }
    }
}
