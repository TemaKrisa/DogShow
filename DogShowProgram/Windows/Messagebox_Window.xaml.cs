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
    /// Interaction logic for Messagebox_Window.xaml
    /// </summary>
    /// 

    public partial class Messagebox_Window : Window
    {
        
        public string nameMessage {
            set
            {
                nameMessage_textbox.Text = value;
            }
        }
        public string Message 
        {
            set
            {
                message_textbox.Text = value;
            }
        }
        public bool error 
        {
            set
            {
                if (value)
                    error_icon.Visibility = Visibility.Visible;
                else
                    error_icon.Visibility = Visibility.Hidden;
            }
        }

        
        public Messagebox_Window()
        {
            InitializeComponent();
        }

        private void Ok_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
