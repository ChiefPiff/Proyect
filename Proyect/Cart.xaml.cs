using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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
    /// Логика взаимодействия для Cart.xaml
    /// </summary>
    public partial class Cart : Window
    {
        string nameToP;
        string priceToP;
        string imageDataToP;
        string quantityToP;
        string userLogin;
        decimal summ;
        string cartFilePath;
        public Cart(string currentUser)
        {
            
            InitializeComponent();
            this.userLogin = currentUser;
            summaryOfItems.Content = summ;
            cartFilePath = $"{currentUser}_Cart.json";
        }

        public void AddItemToCart(Product product)
        {
            CartUserControl item = new CartUserControl(new CartProduct(product));
            cartListView.Items.Add(item);
            summ = summ + product.Price;
            summaryOfItems.Content = summ;

            nameToP = product.Name;
            priceToP = product.Price.ToString();
            imageDataToP = product.ImageData;
            quantityToP = "1";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<CartProduct> cartProducts = new List<CartProduct>();
            foreach (var item in cartListView.Items) 
            {
                CartUserControl cartItem = item as CartUserControl;
                CartProduct cartProduct = cartItem.CartProduct;

                if (cartProduct.RecipeIsNeeded)
                {
                    AddRecipeWindow addRecipeWindow = new AddRecipeWindow(ref cartProduct);
                    addRecipeWindow.ShowDialog();
                }
                cartProducts.Add(cartProduct);
            }

            Order order = new Order(userLogin, cartProducts);
            OrdersDataRepository.AddOrder(order);
            MessageBox.Show("Товар оформлен");
            File.WriteAllText(cartFilePath, string.Empty);

        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            UserWindow userWindow = new UserWindow(userLogin);
            userWindow.Show();

            this.Close();
        }
        //Создать List<CartOrder> внутри у каждого List<CartProduct>
        //Выводить ListView внутри Litview
    }
}
