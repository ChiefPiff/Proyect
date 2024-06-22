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
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        private UserDataService userDataService = new UserDataService();
        public AuthWindow()
        {
            InitializeComponent();

        }

        private void registrationButton_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();

            registrationWindow.Show();
            this.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void authorizationButton_Click(object sender, RoutedEventArgs e)
        {
            string username = loginTextBox.Text;
            string password = passwordTextBox.Text;

            User authenticatedUser = userDataService.LoginUser(username, password);

            if (authenticatedUser != null)
            {
                string userLogin = authenticatedUser.Username;

                MessageBox.Show($"Авторизация успешна. Логин: {userLogin}");

                if (authenticatedUser.Role == UserRole.Administrator)
                {
                    AdminWindow admin = new AdminWindow(userLogin);
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    UserWindow userWindow = new UserWindow(userLogin);
                    userWindow.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }
        }

        //Админ - Принимает заказы у клиента 
        //К товару добавить булевое значение требуемого рецепта
        //В заказ добавить картинку рецепта (Прикрепить рецепт)
        //Заказы на подобии корзины

        private void guestButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
