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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Proyect
{
    /// <summary>
    /// Логика взаимодействия для OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        private Order order;
        public OrderUserControl(Order order)
        {

            InitializeComponent();
            this.order = order;
            OrderStatus = this.order.Status; 
            OrderUserLogin = this.order.UserLogin;
            

            listOfProducts.Items.Clear();
            if(this.order.CartProducts != null ) 
            {
                foreach (var product in this.order.CartProducts)
                {
                    var item = new CartUserControl(product);
                    listOfProducts.Items.Add(item);
                }
            }
                

        }

        public Order GetOrder()
        {
            return this.order;
        }

        public string OrderUserLogin
        {
            get { return orderUserLogin.Text; }
            set
            {
                this.order.UserLogin = value;
                orderUserLogin.Text = value;
            }
        }

        public static readonly DependencyProperty OrderUserLoginProperty =
            DependencyProperty.Register("OrderUserLogin", typeof(string), typeof(OrderUserControl));

        public string OrderStatus
        {
            get { return orderStatus.Text; }
            set
            {
                this.order.Status = value;
                orderStatus.Text = value;
            }
        }
        public static readonly DependencyProperty OrderStatusProperty =
            DependencyProperty.Register("OrderStatus", typeof(string), typeof(OrderUserControl));

    }
}
