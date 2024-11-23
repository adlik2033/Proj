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

namespace Проект.windows
{
    /// <summary>
    /// Логика взаимодействия для FullData.xaml
    /// </summary>
    public partial class FullData : Window
    {
        Yacenko_12Entities455 db;
        public FullData()
        {
            InitializeComponent();
            db = new Yacenko_12Entities455();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgFull.ItemsSource = db.sp_GetSalesReport();
            dgAutos.ItemsSource = db.sp_GetAutoMovementReport();
        }

        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;

                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(st1, "Таблица");
                }
            }
            finally
            {
                IsEnabled = true;
                this.Close();
            }
        }
    }
}
