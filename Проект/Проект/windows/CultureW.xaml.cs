using System;
using System.Collections.Generic;
using System.Data.Common;
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
using Проект.auth;

namespace Проект.windows
{
    /// <summary>
    /// Логика взаимодействия для CultureW.xaml
    /// </summary>
    public partial class CultureW : Window
    {
        Yacenko_12Entities455 db;
        public CultureW()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
            dgCulture.ItemsSource = db.Culture.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Culture cul = new Culture();
                cul.id = Convert.ToInt32(tbId.Text);
                cul.NameCulture = tbNC.Text;
                db.Culture.Add(cul);
                db.SaveChanges();
                dgCulture.ItemsSource = db.Culture.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Action2(object sender, RoutedEventArgs e)
        {
            try
            {
                Culture cul = (Culture)dgCulture.SelectedItem;
                db.Culture.Remove(cul);
                db.SaveChanges();
                dgCulture.ItemsSource = db.Culture.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Action3(object sender, RoutedEventArgs e)
        {
            try
            {
                Culture cul = (Culture)dgCulture.SelectedItem;
                int sUpId = cul.id;
                var selecUptId = db.Culture.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = cul;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgCulture.ItemsSource = db.Culture.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ComboboxW_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxW.SelectedIndex == 0)
            {
                TransactionsWindow transactionsWindow = new TransactionsWindow();
                transactionsWindow.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 1)
            {
                AnimalsW animalsW = new AnimalsW();
                animalsW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 2)
            {
                AutosW autosW = new AutosW();
                autosW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 3)
            {
                ByuerW byuerW = new ByuerW();
                byuerW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 4)
            {
                CultureW cultureW = new CultureW();
                cultureW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 5)
            {
                EmployesW employesW = new EmployesW();
                employesW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 6)
            {
                FarmsW farmsW = new FarmsW();
                farmsW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 7)
            {
                PostW postW = new PostW();
                postW.Show();
                this.Close();
            }
            if (ComboboxW.SelectedIndex == 8)
            {
                WareHouseW arehouseW = new WareHouseW();
                arehouseW.Show();
                this.Close();
            }
        }
        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dgCulture, "Таблица");
                }
            }
            finally
            {
                IsEnabled = true;
            }
        }

        private void DataOpen(object sender, RoutedEventArgs e)
        {
            FullData fullData = new FullData();
            fullData.Show();
        }
    }
}
