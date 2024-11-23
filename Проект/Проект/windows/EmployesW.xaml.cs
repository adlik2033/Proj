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
using Проект.auth;

namespace Проект.windows
{
    /// <summary>
    /// Логика взаимодействия для EmployesW.xaml
    /// </summary>
    public partial class EmployesW : Window
    {
        Yacenko_12Entities455 db;
        public EmployesW()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
            dgEmployes.ItemsSource = db.Employes.ToList();

            var query = from rq in db.Post
                        select rq.NamePost;

            tbPID.ItemsSource = query.ToList();
        }
        private void Action1(object sender, RoutedEventArgs e)
        {
            try
            {
                Employes emp = new Employes();
                emp.id = Convert.ToInt32(tbId.Text);
                emp.FullName = tbFN.Text;
                emp.Age = Convert.ToInt32(tbA.Text);
                emp.Gender = tbG.Text;
                emp.Telephon = tbT.Text;
                emp.Pasport = Convert.ToInt32(tbP.Text);
                emp.PostID = SelectThisObject(tbPID.Text);
                db.Employes.Add(emp);
                db.SaveChanges();
                dgEmployes.ItemsSource = db.Employes.ToList();
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
                Employes emp = (Employes)dgEmployes.SelectedItem;
                db.Employes.Remove(emp);
                db.SaveChanges();
                dgEmployes.ItemsSource = db.Employes.ToList();
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
                Employes emp = (Employes)dgEmployes.SelectedItem;
                int sUpId = emp.id;
                var selecUptId = db.Employes.Where(w => w.id == sUpId).FirstOrDefault();
                if (selecUptId == null)
                {
                    MessageBox.Show("Такого ID в таблице не существует!");
                }
                else
                {
                    selecUptId = emp;
                    MessageBox.Show("Изменения внесены успешно!");
                    db.SaveChanges();
                    dgEmployes.ItemsSource = db.Employes.ToList();
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
            if (EmpsF.SelectedIndex == 0)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgEmployes.ItemsSource = db.Employes.Where(w => w.Age == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (EmpsF.SelectedIndex == 1)
            {
                try
                {
                    string check = TextsF.Text;
                    dgEmployes.ItemsSource = db.Employes.Where(w => w.Gender == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (EmpsF.SelectedIndex == 2)
            {
                try
                {
                    string check = TextsF.Text;
                    dgEmployes.ItemsSource = db.Employes.Where(w => w.Telephon == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (EmpsF.SelectedIndex == 3)
            {
                try
                {
                    int check = Convert.ToInt32(TextsF.Text);
                    dgEmployes.ItemsSource = db.Employes.Where(w => w.PostID == check).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dgEmployes.ItemsSource = db.Employes.ToList();
        }

        private void DataSave(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(dgEmployes, "Таблица");
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
