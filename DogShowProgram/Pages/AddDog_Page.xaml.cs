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
    /// Interaction logic for AddDog_Page.xaml
    /// </summary>
    public partial class AddDog_Page : Page
    {
        public Club club;
        public DogPassport dogPassport;
        public AddDog_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
          Scripts.DataHolder.frame_main.GoBack();
        }

        private void setClub_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeClub_Window window = new Windows.ChangeClub_Window();
            window.AddDog_Page = this;
            window.ShowDialog();
        }

        private void addDog_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                Dog dog = new Dog()
                {
                    IdClub = club.IdClub,
                    MotherNickName = motherNickName_textbox.Text,
                    FatherNickName = fatherNickName_textbox.Text,
                    IdDogPassporty = dogPassport.IdDogPassport
                };
                db.Dog.Add(dog);
                db.SaveChanges();

                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Уведомление", Message = "Собака была добавлен.", error = false };
                messagebox.ShowDialog();

                Scripts.DataHolder.frame_main.GoBack();
            }
        }


        private void setDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeDogPassport_Window window = new Windows.ChangeDogPassport_Window();
            window.addDog_Page = this;
            window.ShowDialog();
        }
    }
}
