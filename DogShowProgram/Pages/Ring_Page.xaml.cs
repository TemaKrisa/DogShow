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
    /// Interaction logic for Ring_Page.xaml
    /// </summary>
    public partial class Ring_Page : Page
    {
        public Ring_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void AddRing_but_Click(object sender, RoutedEventArgs e)
        {
            AddRing_Page page = new AddRing_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }

        private void editRing_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
                datagrid_ring.ItemsSource = db.Ring.ToList();
        }
    }
}
