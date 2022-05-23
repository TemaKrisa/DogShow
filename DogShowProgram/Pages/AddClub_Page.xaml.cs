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
    /// Interaction logic for AddClub_Page.xaml
    /// </summary>
    public partial class AddClub_Page : Page
    {
        public AddClub_Page()
        {
            InitializeComponent();
        }
        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addClub_but_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                Club club = new Club { NameClub = nameClub_textbox.Text, Breed = breedClub_textbox.Text, MinNumber = Convert.ToInt32(minNumber_textbox.Text), MaxNumber = Convert.ToInt32(maxNumber_textbox.Text) };
                db.Club.Add(club);
                db.SaveChanges();
                Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() {nameMessage = "Сообщение", Message = "Клуб добавлен!", error = false};
                messagebox.ShowDialog();
                Scripts.DataHolder.frame_main.GoBack();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                int maxNum = db.Club.Max(p => p.MaxNumber);
                maxNumber_textbox.Text = (maxNum + 10).ToString();
                minNumber_textbox.Text = (maxNum + 1).ToString();

            }
        }
    }
}
