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
    /// Interaction logic for editDogOwner_Page.xaml
    /// </summary>
    public partial class editDogOwner_Page : Page
    {
        public DogOwner owner;
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
    }
}
