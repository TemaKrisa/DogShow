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

        private void addExpert_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.Navigate(new addExpert_Page());
        }

        private void editExpert_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_dog.SelectedIndex;
            string name = null;
            string clubName = null;
            int idRing = 0;

            for (int i = 0; i < 10;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemR = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        name = itemR.Text;
                        break;
                    case 3:
                        TextBlock itemL = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        clubName = itemL.Text;
                        break;
                    case 2:
                        TextBlock itemP = datagrid_dog.Columns[i].GetCellContent(datagrid_dog.Items[r]) as TextBlock;
                        idRing = Convert.ToInt32(itemP.Text);
                        break;

                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                Expert expert = db.Expert.Where(p => p.Name == name && p.Club.NameClub == clubName && p.IdRing == idRing).FirstOrDefault();

                editExpert_Page page = new editExpert_Page()
                {
                    expert = expert,
                };

                page.nameExpert_textbox.Text = expert.Club.NameClub;
                page.surnameExpert_textbox.Text = expert.Surname;
                page.idRing_combobox.Text = Convert.ToString(expert.IdRing);
                page.nameClub_textbox.Text = expert.Club.NameClub;

                Scripts.DataHolder.frame_main.Navigate(page);

                
            }
        }
    }
}
