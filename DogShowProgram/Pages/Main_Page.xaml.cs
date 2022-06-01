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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for Main_Page.xaml
    /// </summary>
    public partial class Main_Page : Page
    {
        public Main_Page()
        {
            InitializeComponent();
        }

        private void club_but_Click(object sender, RoutedEventArgs e)
        {
            Club_Page club_Page = new Club_Page();
            Scripts.DataHolder.frame_main.Navigate(club_Page);
        }

        private void dogAndOther_but_Click(object sender, RoutedEventArgs e)
        {
            DogAndOther_Page page = new DogAndOther_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }

        private void expert_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.Navigate(new Expert_Page());
        }

        private void ring_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.Navigate(new Ring_Page());
        }
    }
}
