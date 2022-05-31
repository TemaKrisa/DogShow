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
    /// Interaction logic for editDog_Page.xaml
    /// </summary>
    public partial class editDog_Page : Page
    {
        public Dog dog;
        public Club club;
        public editDog_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void setDogPassport_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setClub_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void editDog_but_Click(object sender, RoutedEventArgs e)
        {
            using(DogShowEntities db = new DogShowEntities())
            {
                dog.MotherNickName = motherNickName_textbox.Text;
                dog.FatherNickName = fatherNickName_textbox.Text;
                dog.Club = club;

                db.Entry(dog).State = EntityState.Modified;
                db.SaveChanges();              
            }
            Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window()
            {
                nameMessage = "Уведомление",
                Message = "Данные о собаке изменены.",
                error = false
            };
            messagebox.ShowDialog();
            Scripts.DataHolder.frame_main.GoBack();
        }
    }
}
