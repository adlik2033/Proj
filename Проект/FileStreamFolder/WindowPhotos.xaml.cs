using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;
using System.Security.Policy;
using GalaSoft.MvvmLight.Command;
using System.Drawing;
using Проект.Properties;
using static System.Net.WebRequestMethods;
using File = System.IO.File;
using Проект.windows;

namespace Проект.FileStreamFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowPhotos.xaml
    /// </summary>
    public partial class WindowPhotos : Window
    {
        Images52Entities db;
        public WindowPhotos()
        {
            InitializeComponent();
        }
        private void btnSelectImage_Click(object sender, RoutedEventArgs e)
        {
            // Открываем диалоговое окно для выбора изображения
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                // Загружаем изображение и отображаем его
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                image.Source = bitmap;

                // Сохраняем изображение в папку проекта
                string projectPath = AppDomain.CurrentDomain.BaseDirectory; // Получаем путь к папке проекта
                string savePath = System.IO.Path.Combine(projectPath, "SavedImages"); // Указываем папку для сохранения

                // Создаем папку, если она не существует
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }

                // Копируем файл в указанную папку
                string fileName = System.IO.Path.GetFileName(openFileDialog.FileName);
                string destinationPath = System.IO.Path.Combine(savePath, fileName);
                File.Copy(openFileDialog.FileName, destinationPath, true); // true перезаписывает файл, если он существует

                MessageBox.Show($"Изображение сохранено в {destinationPath}");
                SaveDb(destinationPath);
            }
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
            var path11 = (Images)dgPhotos.SelectedItem;
            string path = path11.images1;
            BitmapImage bmp = new BitmapImage();

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                bmp.BeginInit();
                bmp.CacheOption = BitmapCacheOption.OnLoad;
                bmp.StreamSource = fileStream;
                bmp.EndInit();
                if (bmp.CanFreeze)
                    bmp.Freeze();

                image.Source = bmp;
            }
           
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            TransactionsWindow transactionsWindow = new TransactionsWindow();
            transactionsWindow.Show();
            this.Close();
        }
            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Images52Entities();
            dgPhotos.ItemsSource = db.Images.ToList();
        }

        public void SaveDb(string path)
        {
            Images images = new Images();
            images.images1 = path;
            db.Images.Add(images);
            db.SaveChanges();
            dgPhotos.ItemsSource = db.Images.ToList();
            MessageBox.Show("Сохранено");
        }
    }
}
