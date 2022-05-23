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
            using (DogShowEntities db = new DogShowEntities())
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

        private void editClub_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_club.SelectedIndex;

            string nameClub = null;
            string breed = null;
            string maxNumber = null;
            string minNumber = null;

            for (int i = 0; i < 3;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = datagrid_club.Columns[i].GetCellContent(datagrid_club.Items[r]) as TextBlock;
                        nameClub = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = datagrid_club.Columns[i].GetCellContent(datagrid_club.Items[r]) as TextBlock;
                        breed = itemP.Text;
                        break;
                    case 2:
                        TextBlock itemf = datagrid_club.Columns[i].GetCellContent(datagrid_club.Items[r]) as TextBlock;
                        maxNumber = itemf.Text;
                        break;
                    case 3:
                        TextBlock itemS = datagrid_club.Columns[i].GetCellContent(datagrid_club.Items[r]) as TextBlock;
                        minNumber = itemS.Text;
                        break;
                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                Club club = db.Club.Where(p => p.NameClub == nameClub && p.Breed == breed).FirstOrDefault();
                Pages.EditClub_Page editClub = new EditClub_Page();
                editClub.Club = club;
                Scripts.DataHolder.frame_main.Navigate(editClub);
            }
        }
    }
}
