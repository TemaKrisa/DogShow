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
    /// Interaction logic for EditClub_Page.xaml
    /// </summary>
    public partial class EditClub_Page : Page
    {
        Club club;
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
    }
}
