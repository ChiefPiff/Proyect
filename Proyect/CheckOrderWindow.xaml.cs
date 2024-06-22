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
    /// Логика взаимодействия для CheckOrderWindow.xaml
    /// </summary>
    public partial class CheckOrderWindow : Window
    {
        int orderId;
        private Order orderToCheck;
        public CheckOrderWindow(Order order)
        {
            InitializeComponent();
            this.orderToCheck = order;
            this.orderId = order.OrderId;
            userName.Content = order.UserLogin;
            orderStatus.Content = order.Status;

            orderListView.Items.Clear();
            if (this.orderToCheck.CartProducts != null)
            {
                foreach (var product in this.orderToCheck.CartProducts)
                {
                    var item = new CartUserControl(product);
                    orderListView.Items.Add(item);
                }
            }
        }

        private void accesButton_Click(object sender, RoutedEventArgs e)
        {
            orderToCheck.Accept();
            orderStatus.Content = orderToCheck.Status;
        }

        private void declineButton_Click(object sender, RoutedEventArgs e)
        {
            orderToCheck.Decline();
            orderStatus.Content = orderToCheck.Status;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            string finalStatus = orderStatus.Content.ToString();
            OrdersDataRepository.SetOrderStatus(orderId, finalStatus);
            Close();
        }
    }
}
