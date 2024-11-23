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

namespace Проект.FileStreamFolder
{
    /// <summary>
    /// Логика взаимодействия для WindowPhotos.xaml
    /// </summary>
    public partial class WindowPhotos : Window
    {
        public WindowPhotos()
        {
            InitializeComponent();
        }

        // команда сохранения файла
        private void SelectImage(object sender, RoutedEventArgs e)
        {
            string filedirectoty = "./PhotosDirectory";
            using (FileStream fileStream = new FileStream(filedirectoty, FileMode.Create))
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                file
            }
            OpenFileDialog openFileDialog = new OpenFileDialog(); // создаем диалоговое окно
            openFileDialog.ShowDialog(); // показываем
            byte[] image_bytes = File.ReadAllBytes(openFileDialog.FileName); // получаем байты выбранного файла

            string connectionString = "data source=192.168.147.54\\LOL;initial catalog=Images;user id=kek;password=arbidol;MultipleActiveResultSets=True;App=EntityFramework&quot;"; // строка подключения
            using (SqlConnection connection = new SqlConnection(connectionString)) // создаем подключение
            {
                connection.Open(); // открываем соединение
                SqlCommand command = new SqlCommand(); // создаем запрос
                command.Connection = connection; // даем запросу подключение
                command.CommandText = "INSERT INTO images VALUES (@ImageData)"; // основной запрос
                command.Parameters.Add("@ImageData", SqlDbType.Image, 1000000); // параметр ImageData
                command.Parameters["@ImageData"].Value = image_bytes; // сканированный переменной ImageData присвоен массив байтов
                command.ExecuteNonQuery(); // запускаем
            }
        }

        private void LoadImage(object sender, RoutedEventArgs e)
        {
            DataTable matcher_query = SqlModel.Select("SELECT * from Images"); // запрос
            image.Source = ByteImage.Convert(ByteImage.GetImageFromByteArray((byte[])matcher_query.Rows[matcher_query.Rows.Count - 1][0]));
            // берем из запроса последнюю строку и ее массив байтов
        }
    }
}
