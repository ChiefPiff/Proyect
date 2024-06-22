using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace Proyect
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private List<Category> categories;
        private List<Product> products;
        private string currentUser;

        public class CartItem
        {
            public Product product { get; set; }

            public CartItem(Product product)
            {
                this.product = product;
            }
        }



        public UserWindow(string login)
        {
            InitializeComponent();
            currentUser = login;

            //categories = DataRepository.LoadCategories();
            products = DataRepository.LoadProducts();

            productListView.Items.Clear();

            foreach (var product in products)
            {
                var item = new ItemUserControl(product);
                productListView.Items.Add(item);
            }
        }

        private void ViewCategories_Click(object sender, RoutedEventArgs e)
        {

            //dataGrid.ItemsSource = categories;
        }

        private void ViewProducts_Click(object sender, RoutedEventArgs e)
        {

            //itemsControl.Items.Clear();
            productListView.Items.Clear();

            foreach (var product in products)
            {

                var item = new ItemUserControl(product);
                productListView.Items.Add(item);
            }
        }

        private void GoToCart_Click(object sender, RoutedEventArgs e)
        {
            Cart cart = new Cart(currentUser);

            string cartFilePath = $"{currentUser}_Cart.json";

            try
            {

                if (File.Exists(cartFilePath))
                {
                    string json = File.ReadAllText(cartFilePath);


                    if (!string.IsNullOrEmpty(json))
                    {
                        List<CartItem> cartItems = JsonSerializer.Deserialize<List<CartItem>>(json);


                        foreach (var cartItem in cartItems)
                        {
                            cart.AddItemToCart(cartItem.product);
                        }
                    }
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Ошибка при десериализации JSON: {ex.Message}");
            }

            cart.Show();
            this.Close();
        }


        private void AddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (productListView.SelectedItem is ItemUserControl selectedUserControl)
            {
                ImageSource productImageSource = selectedUserControl.ProductImageSource;

                var cartItem = new CartItem(selectedUserControl.GetProduct());

                string cartFilePath = $"{currentUser}_Cart.json";

                List<CartItem> existingCartItems;
                if (File.Exists(cartFilePath))
                {
                    string json = File.ReadAllText(cartFilePath);
                    if (json != "")
                    {
                        existingCartItems = JsonSerializer.Deserialize<List<CartItem>>(json);
                    }
                    else
                    {
                        existingCartItems = new List<CartItem>();
                    }
                    
                }
                else
                {
                    existingCartItems = new List<CartItem>();
                }

                existingCartItems.Add(cartItem);

                string updatedJson = JsonSerializer.Serialize(existingCartItems, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(cartFilePath, updatedJson);

                MessageBox.Show("Товар успешно добавлен в корзину");
            }
        }
    }
}
    

