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

namespace Proyect
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private string reserv1;
        private string reserv2;
        private bool checked1;
        public UserDataService userDataService = new UserDataService();
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string username = loginTextBox.Text;
            string password = password1TextBox.Text;
            string confirmPassword = password2TextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Введены пустые данные");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Пароли не совпадают");
                return;
            }

            if (checked1)
            {
                password = reserv1;
            }


            User newUser = new User
            {
                Username = username,
                Password = password,
                Role = UserRole.Customer
            };

            if (userDataService.RegisterUser(newUser))
            {
                MessageBox.Show("Регистрация успешно завершена.");
                AuthWindow authorizationWindow = new AuthWindow();
                authorizationWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Пользователь с таким именем уже существует. Выберите другое имя пользователя.");
            }



        }

        private void hidePasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            reserv1 = password1TextBox.Text;
            reserv2 = password2TextBox.Text;
            password1TextBox.Text = new string('*', password1TextBox.Text.Length);
            password2TextBox.Text = new string('*', password2TextBox.Text.Length);
            checked1 = true;
        }

        private void hidePasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            password1TextBox.Text = reserv1;
            password2TextBox.Text = reserv2;
            checked1 = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AuthWindow authorizationWindow = new AuthWindow();
            authorizationWindow.Show();
            this.Close();
        }
    }
}
