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
    /// Interaction logic for Expert_Page.xaml
    /// </summary>
    public partial class Expert_Page : Page
    {
        public Expert_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                var table = from u in db.Expert
                            select new
                            {
                                Name = u.Name,
                                Surname = u.Name,
                                IdRing = u.IdRing,
                                NameClub = u.Club.NameClub
                            };
                datagrid_dog.ItemsSource = table.ToList();

            }
        }
    }
}
