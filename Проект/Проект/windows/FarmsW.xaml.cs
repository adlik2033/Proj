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
    /// Логика взаимодействия для FarmsW.xaml
    /// </summary>
    public partial class FarmsW : Window
    {
        Yacenko_12Entities455 db;
        public FarmsW()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
            dgF.ItemsSource = db.Farms.ToList();


            var query1 = from rq in db.Animals
                        select rq.NameAnimals;

            tbAID.ItemsSource = query1.ToList();


            var query2 = from rq in db.Employes
                        select rq.FullName;

            tbEID.ItemsSource = query2.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Farms f = new Farms();
                f.id = Convert.ToInt32(tbId.Text);
                f.locationWH = tblWH.Text;
                f.Capacity = Convert.ToInt32(tbC.Text);
                f.AnimalsID = SelectThisObject1(tbAID.Text); 
                f.EmployesID = SelectThisObject2(tbEID.Text);
                db.Farms.Add(f);
                db.SaveChanges();
                dgF.ItemsSource = db.Farms.ToList();
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
                Farms f = (Farms)dgF.SelectedItem;
                db.Farms.Remove(f);
                db.SaveChanges();
                dgF.ItemsSource = db.Farms.ToList();
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
                Farms wh = (Farms)dgF.SelectedItem;
                int sUpId = wh.id;
                var selecUptId = db.Farms.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = wh;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgF.ItemsSource = db.Farms.ToList();
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FarmsC.SelectedIndex == 0)
            {
                try
                {
                    string check = TextsF.Text;
                    dgF.ItemsSource = db.Farms.Where(w => w.locationWH == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (FarmsC.SelectedIndex == 1)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgF.ItemsSource = db.Farms.Where(w => w.AnimalsID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (FarmsC.SelectedIndex == 2)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgF.ItemsSource = db.Farms.Where(w => w.EmployesID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgF.ItemsSource = db.Farms.ToList();
        }

        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dgF, "Таблица");
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
            var selecUptId = db.Animals.Where(w => w.NameAnimals == objects).FirstOrDefault();
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
