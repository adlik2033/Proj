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
    /// Логика взаимодействия для AutosW.xaml
    /// </summary>
    public partial class AutosW : Window
    {
        Yacenko_12Entities455 db;
        public AutosW()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
            dgAutos.ItemsSource = db.Autos.ToList();

            var query = from rq in db.Post
                        select rq.NamePost;

            tbPID.ItemsSource = query.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Autos au = new Autos();
                au.id = Convert.ToInt32(tbId.Text);
                au.NameAuto = tbNA.Text;
                au.PostID = SelectThisObject(tbPID.Text);
                db.Autos.Add(au);
                db.SaveChanges();
                dgAutos.ItemsSource = db.Autos.ToList();
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
                Autos tr = (Autos)dgAutos.SelectedItem;
                db.Autos.Remove(tr);
                db.SaveChanges();
                dgAutos.ItemsSource = db.Autos.ToList();
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
                Autos tr = (Autos)dgAutos.SelectedItem;
                int sUpId = tr.id;
                var selecUptId = db.Autos.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = tr;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgAutos.ItemsSource = db.Autos.ToList();
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
            if (AutosF.SelectedIndex == 0)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgAutos.ItemsSource = db.Autos.Where(w => w.PostID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (AutosF.SelectedIndex == 1)
            {
                try
                {
                    string check = TextsF.Text;
                    dgAutos.ItemsSource = db.Autos.Where(w => w.NameAuto == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgAutos.ItemsSource = db.Autos.ToList();
        }

        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dgAutos, "Таблица");
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

        private int SelectThisObject(string objects)
        {
            int id = 0;
            var selecUptId = db.Post.Where(w => w.NamePost == objects).FirstOrDefault();

            id = selecUptId.id;
            return id;

        }
    }
}


