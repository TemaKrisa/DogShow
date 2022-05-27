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
    /// Interaction logic for DogOwner_Page.xaml
    /// </summary>
    public partial class DogOwner_Page : Page
    {
        public DogOwner_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using(DogShowEntities db = new DogShowEntities())
            {
                datagrid_dogOwner.ItemsSource = db.DogOwner.ToList();
            }
           
        }

        private void AddClub_but_Click(object sender, RoutedEventArgs e)
        {
            addDogOwner_Page page = new addDogOwner_Page();
            Scripts.DataHolder.frame_main.Navigate(page);
        }

        private void editDogOwner_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_dogOwner.SelectedIndex;

            string surname = null;
            string name = null;
            string passportSeries = null;
            string passportNumber = null;

            for (int i = 0; i < 6;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        surname = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        name = itemP.Text;
                        break;
                    case 5:
                        TextBlock itemf = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        passportSeries = itemf.Text;
                        break;
                    case 6:
                        TextBlock itemS = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        passportNumber = itemS.Text;
                        break;
                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                DogOwner owner = db.DogOwner.Where(p => p.Surname == surname && p.Name == name && p.PassportSeries == Convert.ToInt32(passportSeries) && p.PassportNumber == Convert.ToInt32(passportNumber)).FirstOrDefault();

                editDogOwner_Page editDogOwner = new editDogOwner_Page() { owner = owner };
                Scripts.DataHolder.frame_main.Navigate(editDogOwner);
                
            }
        }
    }
}
