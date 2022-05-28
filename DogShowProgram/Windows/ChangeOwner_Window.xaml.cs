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
using System.Windows.Shapes;

namespace DogShowProgram.Windows
{
    /// <summary>
    /// Interaction logic for ChangeOwner_Window.xaml
    /// </summary>
    public partial class ChangeOwner_Window : Window
    {
        public Page lastWindow;
        public ChangeOwner_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                datagrid_dogOwner.ItemsSource = db.DogOwner.ToList();
            }
        }

        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changeDogOwner_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_dogOwner.SelectedIndex;

            string surname = null;
            string name = null;
            string passportSeries = null;
            string passportNumber = null;

            for (int i = 0; i < 6;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        surname = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        name = itemP.Text;
                        break;
                    case 5:
                        TextBlock itemf = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        passportSeries = itemf.Text;
                        break;
                    case 6:
                        TextBlock itemS = datagrid_dogOwner.Columns[i].GetCellContent(datagrid_dogOwner.Items[r]) as TextBlock;
                        passportNumber = itemS.Text;
                        break;
                }
                i++;
            }
            int series = Convert.ToInt32(passportSeries);
            int number = Convert.ToInt32(passportNumber);

            using (DogShowEntities db = new DogShowEntities())
            {
                DogOwner owner = db.DogOwner.Where(p => p.Surname == surname && p.Name == name && p.PassportSeries == series).FirstOrDefault();
               
            }
        }
    }
}
