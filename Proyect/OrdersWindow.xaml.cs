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
    /// Логика взаимодействия для OrdersWindow.xaml
    /// </summary>
    public partial class OrdersWindow : Window
    {
        private List<Order> orders;
        public OrdersWindow()
        {
            InitializeComponent();
            orders = OrdersDataRepository.LoadOrders();

            ordersListView.Items.Clear();

            foreach (var order in orders)
            {
                var item = new OrderUserControl(order);
                ordersListView.Items.Add(item);
            }
        }

        private void ordersCheck_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ordersListView.SelectedItem != null)
            {
                OrderUserControl selectedOrderControl = (OrderUserControl)ordersListView.SelectedItem;

                CheckOrderWindow checkOrderWindow = new CheckOrderWindow(selectedOrderControl.GetOrder());
                if (checkOrderWindow.ShowDialog() == true)
                {
                    orders = OrdersDataRepository.LoadOrders();
                }
            }
            else
            {
                MessageBox.Show("Выберите заказ для рассмотрения.");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = "admin";
            AdminWindow adminWingow = new AdminWindow(login);
            adminWingow.Show();

            this.Close();

        }

        private void ordersListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
