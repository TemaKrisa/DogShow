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
    /// Interaction logic for Authorization_Window.xaml
    /// </summary>
    public partial class Authorization_Window : Window
    {
        public Authorization_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Pages.Authorization_Page page = new Pages.Authorization_Page();
            Frame_main.Navigate(page);
        }
    }
}
