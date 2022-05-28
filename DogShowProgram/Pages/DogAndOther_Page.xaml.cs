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
    /// Interaction logic for DogAndOther_Page.xaml
    /// </summary>
    public partial class DogAndOther_Page : Page
    {
        public DogAndOther_Page()
        {
            InitializeComponent();
        }

        private void dogOwner_but_Click(object sender, RoutedEventArgs e)
        {
            DogOwner_Page dogOwner = new DogOwner_Page();
            Scripts.DataHolder.frame_main.Navigate(dogOwner);
        }

        private void dogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            DogPassport_Page page = new DogPassport_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }
    }
}
