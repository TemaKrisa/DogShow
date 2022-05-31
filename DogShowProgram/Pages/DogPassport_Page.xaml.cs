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

        private void editDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_dogPassport.SelectedIndex;

            string nickName = null;
            string LastDateVaccination = null;
            string Gender = null;
            string breed = null;

            for (int i = 0; i < 6;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        nickName = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        LastDateVaccination = itemP.Text;
                        break;
                    case 2:
                        TextBlock itemf = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        Gender = itemf.Text;
                        break;
                    case 4:
                        TextBlock itemS = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        breed = itemS.Text;
                        break;
                }
                i++;
            }
            

            using (DogShowEntities db = new DogShowEntities())
            {
                DogPassport passport = db.DogPassport.Where(p => p.NickName == nickName && p.Gender == Gender && p.Breed == breed).FirstOrDefault();

                EditDogPassport_Page page = new EditDogPassport_Page() {
                    passport = passport
                };
                page.nickName_textbox.Text = passport.NickName;
                page.gender_cb.Text = passport.Gender;
                page.breed_textbox.Text = passport.Breed;
                page.vaccinationDate_datePic.SelectedDate = passport.LastDateVaccination;
                page.brithdayDate_datePic.SelectedDate = passport.BrithdayDate;

                page.nameOwner_textbox.Text = passport.DogOwner.Name;
                page.surnameOwner_textbox.Text = passport.DogOwner.Surname;
                page.pathronymicOwner_textbox.Text = passport.DogOwner.Pathronymic;

                page.owner = passport.DogOwner;

                Scripts.DataHolder.frame_main.Navigate(page);
            }
        }
    }
}
