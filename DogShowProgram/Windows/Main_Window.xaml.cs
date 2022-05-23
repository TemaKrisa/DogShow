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

namespace DogShowProgram.Windows
{
    /// <summary>
    /// Interaction logic for Main_Window.xaml
    /// </summary>
    public partial class Main_Window : Window
    {
        public Main_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main = frame_main;
            Pages.Main_Page main_Page = new Pages.Main_Page();
            frame_main.Navigate(main_Page);
        }
    }
}
