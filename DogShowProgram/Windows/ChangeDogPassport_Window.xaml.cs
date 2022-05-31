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
    /// Interaction logic for ChangeDogPassport_Window.xaml
    /// </summary>
    public partial class ChangeDogPassport_Window : Window
    {
        public Pages.AddDog_Page addDog_Page;

        public ChangeDogPassport_Window()
        {
            InitializeComponent();
        }
        private void back_but_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void changeDogPassport_but_Click(object sender, RoutedEventArgs e)
        {
            int r = datagrid_dogPassport.SelectedIndex;

            string nickName = null;
            string gender = null;
            string breed = null;

            for (int i = 0; i < 3;)
            {
                switch (i)
                {
                    case 0:
                        TextBlock itemL = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        nickName = itemL.Text;
                        break;
                    case 1:
                        TextBlock itemP = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        gender = itemP.Text;
                        break;
                    case 2:
                        TextBlock itemf = datagrid_dogPassport.Columns[i].GetCellContent(datagrid_dogPassport.Items[r]) as TextBlock;
                        breed = itemf.Text;
                        break;
                }
                i++;
            }

            using (DogShowEntities db = new DogShowEntities())
            {
                DogPassport passport = db.DogPassport.Where(p => p.NickName == nickName && p.Gender == gender && p.Breed == breed).FirstOrDefault();

                addDog_Page.dogPassport = passport;
                addDog_Page.nickNameDog_textbox.Text = passport.NickName;
                this.Close();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {
                datagrid_dogPassport.ItemsSource = db.DogPassport.ToList();
            }
        }
    }
}
