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
using Проект.FileStreamFolder;

namespace Проект.windows
{
    /// <summary>
    /// Логика взаимодействия для WareHouseW.xaml
    /// </summary>
    public partial class WareHouseW : Window
    {
        Yacenko_12Entities455 db;
        public WareHouseW()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
            dgWH.ItemsSource = db.WareHouse.ToList();


            var query1 = from rq in db.Culture
                         select rq.NameCulture;

            tbCID.ItemsSource = query1.ToList();


            var query2 = from rq in db.Employes
                         select rq.FullName;

            tbEID.ItemsSource = query2.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                WareHouse wh = new WareHouse();
                wh.id = Convert.ToInt32(tbId.Text);
                wh.locationWH = tblWH.Text;
                wh.Capacity = Convert.ToInt32(tbC.Text);
                wh.CultureID = SelectThisObject1(tbCID.Text);
                wh.EmployesID = SelectThisObject2(tbEID.Text);
                db.SaveChanges();
                dgWH.ItemsSource = db.WareHouse.ToList();
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
                WareHouse wh = (WareHouse)dgWH.SelectedItem;
                db.WareHouse.Remove(wh);
                db.SaveChanges();
                dgWH.ItemsSource = db.WareHouse.ToList();
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
                WareHouse wh = (WareHouse)dgWH.SelectedItem;
                int sUpId = wh.id;
                var selecUptId = db.WareHouse.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = wh;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgWH.ItemsSource = db.WareHouse.ToList();
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
            if (ComboboxW.SelectedIndex == 9)
            {
                WindowPhotos wp = new WindowPhotos();
                wp.Show();
                this.Close();
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (WHC.SelectedIndex == 0)
            {
                try
                {
                    string check = TextsF.Text;
                    dgWH.ItemsSource = db.WareHouse.Where(w => w.locationWH == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (WHC.SelectedIndex == 1)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgWH.ItemsSource = db.WareHouse.Where(w => w.CultureID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (WHC.SelectedIndex == 2)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgWH.ItemsSource = db.WareHouse.Where(w => w.EmployesID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgWH.ItemsSource = db.WareHouse.ToList();
        }

        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dgWH, "Таблица");
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

        private int SelectThisObject1(string objects)
        {
            int id = 0;
            var selecUptId = db.Culture.Where(w => w.NameCulture == objects).FirstOrDefault();
            id = selecUptId.id;
            return id;

        }

        private int SelectThisObject2(string objects)
        {
            int id = 0;
            var selecUptId = db.Employes.Where(w => w.FullName == objects).FirstOrDefault();
            id = selecUptId.id;
            return id;

        }
    }
}
