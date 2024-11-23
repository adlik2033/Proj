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
using Проект.windows;

namespace Проект.auth
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Window
    {
        Yacenko_12Entities455 db;
        int Attection = 0;
        public Auth()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new Yacenko_12Entities455();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Attection == 2)
            {
                Captcha captcha = new Captcha();
                captcha.ShowDialog();
                Attection = 0;
            }
            else
            {
                try
                {
                    string UserLogin = Login.Text;
                    string UserPassword = Password.Password;
                    var selecUptId = db.Users.Where(w => w.Login == UserLogin).FirstOrDefault();
                    if (selecUptId == null)
                    {
                        MessageBox.Show("Такого пользователя не существует!");
                        Attection += 1;
                    }
                    else
                    {
                        if (selecUptId.Password == UserPassword)
                        {
                            MessageBox.Show("Вы успешно вошли в систему!");
                            EmployesW employesW = new EmployesW();
                            employesW.Show();
                            this.Close();
                        }
                        else
                        {
                            Attection += 1;
                            MessageBox.Show("Пароль неверный! Повторите попытку позже");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           
        }
    }
}
