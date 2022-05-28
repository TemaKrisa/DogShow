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
    /// Interaction logic for DogPassport_Page.xaml
    /// </summary>
    public partial class DogPassport_Page : Page
    {
        public DogPassport_Page()
        {
            InitializeComponent();
        }     

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using(DogShowEntities db = new DogShowEntities())
            {
                var table = from u in db.DogPassport
                            join c in db.DogOwner on u.IdDogOwner equals c.IdDogOwner
                            select new
                            {
                                NickName = u.NickName,
                                LastDateVaccination = u.LastDateVaccination,
                                Gender = u.Gender,
                                Breed = u.Breed,
                                BrithdayDate = u.BrithdayDate,
                                DogOwner = c.Surname + " " +  c.Name + " " + c.Pathronymic 
                            };
                datagrid_dogPassport.ItemsSource = table.ToList();
            }
          
        }

        private void back_but_Click_1(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            AddDogPassport_Page page = new AddDogPassport_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }
    }
}
