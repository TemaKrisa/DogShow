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
    /// Interaction logic for Dog_Page.xaml
    /// </summary>
    public partial class Dog_Page : Page
    {
        public Dog_Page()
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
                var table = from u in db.Dog
                            select new
                            {
                                NickName = u.DogPassport.NickName,
                                NameClub = u.Club.NameClub,
                                MotherNickName = u.MotherNickName,
                                FatherNickName = u.FatherNickName,
                                FullName = u.DogPassport.DogOwner.Surname + " " + u.DogPassport.DogOwner.Name + " " + u.DogPassport.DogOwner.Pathronymic
                            };
                datagrid_dog.ItemsSource = table.ToList();

            }
        }

        private void editDog_but_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
