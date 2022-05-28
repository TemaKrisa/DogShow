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
    /// Interaction logic for AddDogPassport_Page.xaml
    /// </summary>
    public partial class AddDogPassport_Page : Page
    {
        DogOwner owner;
        public AddDogPassport_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addOwner_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setOwner_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeOwner_Window window = new Windows.ChangeOwner_Window();
            window.lastWindow = this;
            window.ShowDialog();
        }
    }
}
