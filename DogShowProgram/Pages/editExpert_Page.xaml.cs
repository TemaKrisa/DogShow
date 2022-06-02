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
using System.Data.Entity;

namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for editExpert_Page.xaml
    /// </summary>
    public partial class editExpert_Page : Page
    {
        public Expert expert;
        public Club club;
        public editExpert_Page()
        {
            InitializeComponent();
           
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void editExpert_but_Click(object sender, RoutedEventArgs e)
        {
            expert.Name = nameExpert_textbox.Text;
            expert.Surname = surnameExpert_textbox.Text;
            expert.IdRing = Convert.ToInt32( idRing_combobox.Text);
            

            using (DogShowEntities db = new DogShowEntities())
            {
                db.Entry(expert).State = EntityState.Modified;
                db.SaveChanges();

                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() 
                { 
                    nameMessage = "Уведомление",
                    Message = "Эксперт был изменён.",
                    error = false 
                };
                messagebox.ShowDialog();
            }
            Scripts.DataHolder.frame_main.GoBack();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                idRing_combobox.ItemsSource = db.Ring.ToList();
            }
        }

        private void setClub_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeClub_Window changeClub = new Windows.ChangeClub_Window() { editExpert = this };
            changeClub.ShowDialog();
            nameClub_textbox.Text = expert.Club.NameClub;
        }
    }
}
