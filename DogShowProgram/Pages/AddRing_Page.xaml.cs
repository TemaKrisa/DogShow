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
using Xceed.Wpf.Toolkit;


namespace DogShowProgram.Pages
{
    /// <summary>
    /// Interaction logic for AddRing_Page.xaml
    /// </summary>
    public partial class AddRing_Page : Page
    {
        public AddRing_Page()
        {
            InitializeComponent();
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            
                System.Windows.MessageBox.Show($"{startTime_tp.Value}");

            Scripts.DataHolder.frame_main.GoBack();
        }

        private void addRing_but_Click(object sender, RoutedEventArgs e)
        { 
            string startTimeSt = startTime_tp.Value.ToString();
            DateTime startTimeDt = Convert.ToDateTime(startTimeSt);

            string endTimeSt = end_tp.Value.ToString();
            DateTime endTimeDt = Convert.ToDateTime(endTimeSt);

            Ring ring = new Ring()
            {
                Breed = breed_combobox.Text,
                Date = selectDate_datePic.DisplayDate,
                StartTime = startTimeDt.TimeOfDay,
                EndTime = endTimeDt.TimeOfDay
            };

            using (DogShowEntities db = new DogShowEntities())
            {
                db.Ring.Add(ring);
                db.SaveChanges();
            }
            Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window()
            {
                nameMessage = "Уведомление",
                Message = "Ринг был добавлен.",
                error = false
            };
            messagebox.ShowDialog();
            Scripts.DataHolder.frame_main.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                breed_combobox.ItemsSource = db.Club.ToList();
                idRing_textbox.Text = (string)((db.Ring.Max(p => p.IdRing) + 1).ToString());
            }
        }

        private void startTime_tp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }
    }
}
