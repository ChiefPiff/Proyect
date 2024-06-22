using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private List<Category> categories;
        private List<Product> products;
        private string currentUser;

        public AdminWindow(string login)
        {
            InitializeComponent();
            currentUser = login;

            //categories = DataRepository.LoadCategories();
            products = DataRepository.LoadProducts();

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
            productListView.Items.Clear();

            foreach (var product in products)
            {
                var item = new ItemUserControl(product);
                productListView.Items.Add(item);
            }
        }

        private BitmapImage LoadImageFromBytes(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0)
            {
                return null;
            }

            BitmapImage bitmapImage = new BitmapImage();
            using (MemoryStream stream = new MemoryStream(imageData))
            {
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = stream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
            }

            return bitmapImage;
        }




        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {

            AddProductWindow addProductWindow = new AddProductWindow();
            if (addProductWindow.ShowDialog() == true)
            {

                products = DataRepository.LoadProducts();
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (productListView.SelectedItem != null)
            {
                ItemUserControl selectedProductControl = (ItemUserControl)productListView.SelectedItem;

                EditProductWindow editProductWindow = new EditProductWindow(selectedProductControl.GetProduct());
                if (editProductWindow.ShowDialog() == true)
                {
                    products = DataRepository.LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для редактирования.");
            }
        }


        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            ItemUserControl selectedProductControl = (ItemUserControl)productListView.SelectedItem;

            if (selectedProductControl != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить товар?", "Подвердить", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    Product productToRemove = products.FirstOrDefault(product => product.Name == selectedProductControl.productNameLabel.Text);

                    if (productToRemove != null)
                    {
                        products.Remove(productToRemove);

                        productListView.Items.Remove(selectedProductControl);

                        DataRepository.SaveProducts(products);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите товар для удаления.");
            }
        }



        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {

            AddCategoryWindow addCategoryWindow = new AddCategoryWindow();
            if (addCategoryWindow.ShowDialog() == true)
            {

                //categories = DataRepository.LoadCategories();
            }
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            //Category selectedCategory = dataGrid.SelectedItem as Category;
            //if (selectedCategory != null)
            //{
            //    EditCategoryWindow editCategoryWindow = new EditCategoryWindow(selectedCategory);
            //    if (editCategoryWindow.ShowDialog() == true)
            //    {
            //        categories = DataRepository.LoadCategories();
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Выберите категорию для редактирования.");
            //}
        }

        private void RemoveCategory_Click(object sender, RoutedEventArgs e)
        {
            //Category selectedCategory = dataGrid.SelectedItem as Category;
            //if (selectedCategory != null)
            //{
            //    MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить эту категорию?", "Подтвердить", MessageBoxButton.YesNo);
            //    if (result == MessageBoxResult.Yes)
            //    {
            //        categories.Remove(selectedCategory);
            //        DataRepository.SaveCategories(categories);
            //        dataGrid.ItemsSource = null;
            //        dataGrid.ItemsSource = categories;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Выберите категорию для удаления.");
            //}
        }

        private void CheckOrders_Click(object sender, RoutedEventArgs e)
        {
            OrdersWindow orders = new OrdersWindow();
            orders.Show();

            this.Close();
        }
    }
}
