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
using System.Data.Entity;
using System.Windows.Shapes;

namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for editDogOwner_Page.xaml
    /// </summary>
    public partial class editDogOwner_Page : Page
    {
        public DogOwner owner = new DogOwner();
        public editDogOwner_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            nameOwner_textbox.Text = owner.Name;
            surname_textbox.Text = owner.Surname;
            pathronymicOwner_textbox.Text = owner.Pathronymic;
            birthdayDate_datePic.SelectedDate = owner.BirthdayDate;
            passportNumberOwner_textbox.Text = Convert.ToString( owner.PassportNumber);
            passportSeriesOwner_textbox.Text = Convert.ToString(owner.PassportSeries);
            gender_cb.Text = owner.Gender;
        }

        private void editOwner_but_Click(object sender, RoutedEventArgs e)
        {
            owner.Name = nameOwner_textbox.Text;
            owner.Surname = surname_textbox.Text;
            owner.Pathronymic = pathronymicOwner_textbox.Text;
            owner.BirthdayDate = Convert.ToDateTime( birthdayDate_datePic.Text);
            owner.PassportNumber = Convert.ToInt32(passportNumberOwner_textbox.Text);
            owner.PassportSeries = Convert.ToInt32(passportSeriesOwner_textbox.Text);
            owner.Gender = gender_cb.Text;

            using(DogShowEntities db = new DogShowEntities())
            {
                db.Entry(owner).State = EntityState.Modified;
                db.SaveChanges();
            }
            Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Уведомление", Message = "Владелец был изменён", error = false };
            messagebox.ShowDialog();
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void deleteDogOwner_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                db.Entry(owner).State = EntityState.Deleted;
                db.SaveChanges();
                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Уведомление", Message = "Владелец был удалён!", error = false };
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();
            }
        }
    }
}
