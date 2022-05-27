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
    /// Interaction logic for EditClub_Page.xaml
    /// </summary>
    public partial class EditClub_Page : Page
    {
        Club club = new Club();
        public Club Club
        {
            set
            {
                club = value;
            }
        }
        public EditClub_Page()
        {
            InitializeComponent();
        }
        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            nameClub_textbox.Text = club.NameClub;
            breedClub_textbox.Text = club.Breed;
            maxNumber_textbox.Text = Convert.ToString(club.MaxNumber);
            minNumber_textbox.Text = Convert.ToString(club.MinNumber);
        }

        private void deleteClub_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                db.Entry(club).State = EntityState.Deleted;
                db.SaveChanges();
                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() {nameMessage = "Уведомление", Message = "Клуб был успешна удалён!", error = false};
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();
            }
        }

        private void editClub_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                club.NameClub = nameClub_textbox.Text;
                club.Breed = breedClub_textbox.Text;
                db.Entry(club).State = EntityState.Modified;
                db.SaveChanges();
                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Уведомление", Message = "Клуб был изменён", error = false };
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();
            }
        }
    }
}
