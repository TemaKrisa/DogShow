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
            int r = datagrid_dog.SelectedIndex;
            string clubName = null;
            string motherNick = null;
            string fatherNick = null;

            for (int i = 0; i < 10;)
            {
                switch (i)
                {
                    case 1:
                        TextBlock itemR = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        clubName = itemR.Text;
                        break;
                    case 2:
                        TextBlock itemL = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        motherNick = itemL.Text;
                        break;
                    case 3:
                        TextBlock itemP = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        fatherNick = itemP.Text;
                        break;

                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                Dog dog = db.Dog.Where(p => p.Club.NameClub == clubName && p.MotherNickName == motherNick && p.FatherNickName == fatherNick).FirstOrDefault();

                editDog_Page page = new editDog_Page() { dog = dog ,club = dog.Club};

                page.nickNameDog_textbox.Text = dog.DogPassport.NickName;
                page.motherNickName_textbox.Text = dog.MotherNickName;
                page.fatherNickName_textbox.Text = dog.FatherNickName;
                page.clubName_textbox.Text = dog.Club.NameClub;
                page.breedClub_textbox.Text = dog.Club.Breed;

                Scripts.DataHolder.frame_main.Navigate(page);
            }
        }

        private void addDog_but_Click(object sender, RoutedEventArgs e)
        {
            AddDog_Page page = new AddDog_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }
    }
}
