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
using System.Windows.Shapes;

namespace DogShowProgram.Windows
{
    /// <summary>
    /// Interaction logic for ChangeClub_Window.xaml
    /// </summary>
    public partial class ChangeClub_Window : Window
    {
        public Pages.AddDog_Page AddDog_Page = new Pages.AddDog_Page();
        public Pages.addExpert_Page addExpert_Page = new Pages.addExpert_Page();
        public Pages.editExpert_Page editExpert = new Pages.editExpert_Page();
        public ChangeClub_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                datagrid_club.ItemsSource = db.Club.ToList();
            }

        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changeClub_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_club.SelectedIndex;

            string nameClub = null;
            string breed = null;

            for (int i = 0; i < 1;)
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
                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                Club club = db.Club.Where(p => p.NameClub == nameClub).FirstOrDefault();

                AddDog_Page.clubName_textbox.Text = club.NameClub;
                AddDog_Page.breedClub_textbox.Text = club.Breed;

                AddDog_Page.club = club;
                addExpert_Page.club = club;

                editExpert.expert.Club = club;
                editExpert.expert.IdClub = club.IdClub;

                this.Close();
            }
        }
    }
}
