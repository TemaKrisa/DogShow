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
    /// Interaction logic for Authorization_Page.xaml
    /// </summary>
    public partial class Authorization_Page : Page
    {
        public Window win = new Window();
        
        public Authorization_Page()
        {
            InitializeComponent();
        }

        private void Close_but_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Min_but_Click(object sender, RoutedEventArgs e)
        {
            win.WindowState = WindowState.Minimized;
        }

        private void authorization_Button_Click(object sender, RoutedEventArgs e)
        {
            using (DogShowEntities db = new DogShowEntities())
            {

                User user = db.User.Where(p => p.Login == login_Textbox.Text && p.Password == password_Textbox.Text).FirstOrDefault();
                if (user == null)
                {
                    Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Ошибка", Message = "Введённый логин или пароль не верный!", error = true };
                    messagebox.ShowDialog();
                    return;
                }
                if (user.Login == null || user.Password == null)
                {
                    Windows.Messagebox_Window messagebox = new Windows.Messagebox_Window() { nameMessage = "Ошибка", Message = "Введённый логин или пароль не верный!" ,error = true };
                    messagebox.ShowDialog();
                    return;
                }
                Windows.Сaptcha_Window captcha = new Windows.Сaptcha_Window() { nameMessage = "Введите капчу" };
                captcha.ShowDialog();
            }
            
        }
    }
}
