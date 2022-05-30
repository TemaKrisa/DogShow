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
    /// Interaction logic for AddDogPassport_Page.xaml
    /// </summary>
    public partial class AddDogPassport_Page : Page
    {
        public DogOwner owner;
        public AddDogPassport_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addOwner_but_Click(object sender, RoutedEventArgs e)
        {

        }

        private void setOwner_but_Click(object sender, RoutedEventArgs e)
        {
            Windows.ChangeOwner_Window window = new Windows.ChangeOwner_Window();
            window.dogPassport_Page = this;
            window.ShowDialog();
        }

        private void addDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities()) {
                DogPassport passport = new DogPassport
                {
                    NickName = nickName_textbox.Text,
                    Gender = gender_cb.Text,
                    Breed = breed_textbox.Text,
                    LastDateVaccination = vaccinationDate_datePic.DisplayDate,
                    BrithdayDate = brithdayDate_datePic.DisplayDate,
                    IdDogOwner = owner.IdDogOwner
                };
                db.DogPassport.Add(passport);
                db.SaveChanges();

                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() 
                {
                    nameMessage = "Уведомление", 
                    Message = "Паспорт собаки добавлен.", 
                    error = false 
                };
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();
            }

        }
    }
}
