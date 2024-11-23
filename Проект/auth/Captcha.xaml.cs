using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;

namespace Проект.auth
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        string text = String.Empty;
        public Captcha()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CreateCaptha(100, 50);
        }

        
        private void CreateCaptha(int width, int height)
        {
            Random rnd = new Random();

            Bitmap captha = new Bitmap(width, height);

            int X = rnd.Next(0, width - 50);
            int Y = rnd.Next(0, height - 50);

            Graphics location = Graphics.FromImage((System.Drawing.Image)captha);
            location.RotateTransform(rnd.Next(10, 25));

            System.Drawing.Brush[] colors = new System.Drawing.Brush[] {System.Drawing.Brushes.Black,
                                                                        System.Drawing.Brushes.Blue,
                                                                        System.Drawing.Brushes.Orange,
                                                                        System.Drawing.Brushes.Green,
                                                                        System.Drawing.Brushes.Red};

            location.Clear(System.Drawing.Color.Gray);

            string alphabet = "0123456789QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; i++)
            {
                text += alphabet[rnd.Next(alphabet.Length)];
            }

            location.DrawString(text, new Font("Comic Sans MS", rnd.Next(7, 17)), colors[rnd.Next(colors.Length)], new PointF(X, Y));

            location.DrawLine(Pens.Black, new System.Drawing.Point(0, 0), new System.Drawing.Point(width - 1, height - 1));
            location.DrawLine(Pens.Black, new System.Drawing.Point(0, height - 1), new System.Drawing.Point(width - 1, 0));

            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                    if (rnd.Next() % 25 == 0)
                    {
                        captha.SetPixel(i, j, System.Drawing.Color.White);
                    }
            System.Windows.Media.Imaging.BitmapImage bitmapimage = new System.Windows.Media.Imaging.BitmapImage();
            using (MemoryStream memory = new MemoryStream())
            {
                captha.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bmp = new BitmapImage();
                bmp.BeginInit();
                bmp.StreamSource = memory;
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.EndInit();
                bitmapimage = bmp;
            }

            Captha.Source = bitmapimage;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if((bool)Check.IsChecked && textCheck.Text == text)
            {
                MessageBox.Show("Вы не робот! Поздравляю");
                this.Close();
            }
            else
            {
                MessageBox.Show("Повторите попытку!");
            }
        }

        //private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        //{
        //    if(e.Cancel == true)
        //    {
        //        var result = MessageBox.Show("Окно закрыть нельзя!", "Предупреждение", MessageBoxButton.OKCancel);
        //        if(result == MessageBoxResult.Cancel) 
        //        {
        //            e.Cancel = false;
        //        }
        //    }
        //}
    }
}
