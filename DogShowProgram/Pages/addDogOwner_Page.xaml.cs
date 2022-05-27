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
    /// Interaction logic for addDogOwner_Page.xaml
    /// </summary>
    public partial class addDogOwner_Page : Page
    {
        public addDogOwner_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addOwner_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                DogOwner dogOwner = new DogOwner()
                {
                    Name = nameOwner_textbox.Text,
                    Surname = surname_textbox.Text,
                    Pathronymic = pathronymicOwner_textbox.Text,
                    Gender = gender_cb.Text,
                    PassportSeries = Convert.ToInt32(passportSeriesOwner_textbox.Text),
                    PassportNumber = Convert.ToInt32(passportNumberOwner_textbox.Text),
                    BirthdayDate = Convert.ToDateTime(birthdayDate_datePic.Text)
                };
                db.DogOwner.Add(dogOwner);
                db.SaveChanges();
                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Уведомление", Message = "Владелец собаки добавлен.", error = false };
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();

            }
        }
    }
}
