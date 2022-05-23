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
    /// Interaction logic for Сaptcha_Window.xaml
    /// </summary>
    public partial class Сaptcha_Window : Window
    {
        public string nameMessage
        {
            set
            {
                nameMessage_textbox.Text = value;
            }
        }
        string result = null;
        public Window win = new Window();
        Random _random = new Random();

        public Сaptcha_Window()
        {
            InitializeComponent();
            UpdateCaptcha();
        }
        private void UpdateCaptcha()

        {

            SPanelSymbols.Children.Clear();

            CanvasNoise.Children.Clear();

            //количество символов

            GenerateSymbols(4);

            //количество элементов шума

            GenerateNoise(10);

        }

        //создание символов

        private void GenerateSymbols(int count)
        {
           

            string alphabet = "WERPASFHKXVBM234578";

            for (int i = 0; i < count; i++)

            {

                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();

                
                result += $"{symbol}";

                TextBlock lbl = new TextBlock();

                lbl.Text = symbol;

                lbl.FontSize = _random.Next(30, 50);

                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));

                lbl.Margin = new Thickness(20, 0, 20, 0);

                SPanelSymbols.Children.Add(lbl);

            }

        }

        //шум

        private void GenerateNoise(int volumeNoise)

        {

            for (int i = 0; i < volumeNoise; i++)

            {

                Border border = new Border();

                border.Background = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),

                (byte)_random.Next(0, 256),

                (byte)_random.Next(0, 256),

                (byte)_random.Next(0, 256)));

                border.Height = _random.Next(2, 10);

                border.Width = _random.Next(10, 400);

                border.RenderTransform = new RotateTransform(_random.Next(0, 360));

                CanvasNoise.Children.Add(border);

                Canvas.SetLeft(border, _random.Next(0, 300));

                Canvas.SetTop(border, _random.Next(0, 150));

                Ellipse ellipse = new Ellipse();

                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),

                (byte)_random.Next(0, 256),

                (byte)_random.Next(0, 256),

                (byte)_random.Next(0, 256)));

                ellipse.Height = ellipse.Width = _random.Next(20, 40);

                CanvasNoise.Children.Add(ellipse);

                Canvas.SetLeft(ellipse, _random.Next(0, 300));

                Canvas.SetTop(ellipse, _random.Next(0, 150));

            }

        }

        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)

        {

            UpdateCaptcha();

        }

        private void Ok_button_Click(object sender, RoutedEventArgs e)
        {
            if (result == enter_textbox.Text)
                MessageBox.Show("Всё ок!");
            else
            {
                enter_textbox.Text = string.Empty;
                result = null;
                MessageBox.Show("Ты дэбил");
                UpdateCaptcha();
            }
        }
    }
}
