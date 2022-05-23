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
    /// Interaction logic for Club_Page.xaml
    /// </summary>
    public partial class Club_Page : Page
    {
        public Club_Page()
        {
            InitializeComponent();
        }

        private void datagrid_club_Loaded(object sender, RoutedEventArgs e)
        {
           using(DogShowEntities db = new DogShowEntities())
            {
                datagrid_club.ItemsSource = db.Club.ToList();
            }
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void AddClub_but_Click(object sender, RoutedEventArgs e)
        {
            AddClub_Page addClub_Page = new AddClub_Page();
            Scripts.DataHolder.frame_main.Navigate(addClub_Page);
        }
    }
}
