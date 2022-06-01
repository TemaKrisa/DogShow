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
    /// Interaction logic for addExpert_Page.xaml
    /// </summary>
    public partial class addExpert_Page : Page
    {
        public Club club;
        public addExpert_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addExpert_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                Expert expert = new Expert()
                {
                    Name = nameExpert_textbox.Text,
                    Surname = surnameExpert_textbox.Text,
                    IdRing = Convert.ToInt32(idRing_combobox.Text),
                    IdClub = club.IdClub
                };
                db.Expert.Add(expert);
                db.SaveChanges();
            }
            Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() 
            { 
                nameMessage = "Уведомление", 
                Message = "Эксперт был добавлен.", 
                error = false 
            };
            messagebox.ShowDialog();
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void setClub_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeClub_Window changeClub = new Windows.ChangeClub_Window() { addExpert_Page = this };
            changeClub.ShowDialog();
            nameClub_textbox.Text = club.NameClub;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
            using (DogShowEntities db = new DogShowEntities()) 
            {
                idRing_combobox.ItemsSource = db.Ring.ToList();
            }
               
        }
    }
}
