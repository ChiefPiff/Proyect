using Microsoft.Win32;
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
    /// Логика взаимодействия для EditProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        private Product productToEdit;


        public EditProductWindow(Product product)
        {
            InitializeComponent();
            productToEdit = product;
            productNameTextBox.Text = product.Name;
            productPriceTextBox.Text = product.Price.ToString();
            productManufacturerTextBox.Text = product.Manufacturer;
            quantityTextBox.Text = product.Quantity.ToString();

            if (!string.IsNullOrEmpty(product.ImageData))
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(product.ImageData);
                bitmap.EndInit();
                productImageBox.Source = bitmap;
            }
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = productNameTextBox.Text;
            decimal price = decimal.Parse(productPriceTextBox.Text);
            string manufacturer = productManufacturerTextBox.Text;
            int.TryParse(quantityTextBox.Text, out int quantity);

            if (decimal.TryParse(productPriceTextBox.Text, out price) && int.TryParse(quantityTextBox.Text, out quantity))
            {
                productToEdit.Name = name;
                productToEdit.Price = price;
                productToEdit.Quantity = quantity;
                productToEdit.Manufacturer = manufacturer;
                productToEdit.ImageData = productImageBox.Source.ToString();


                DataRepository.UpdateProduct(productToEdit);
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg, *.png)|*.jpg;*.png",
                Title = "Выберите фото"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath));
                productImageBox.Source = bitmapImage;
            }
        }

        private void IncreaseButtonClick(object sender, RoutedEventArgs e)
        {
            int currentValue;
            if (int.TryParse(quantityTextBox.Text, out currentValue))
            {
                currentValue++;
                quantityTextBox.Text = currentValue.ToString();
            }
        }

        private void DecreaseButtonClick(object sender, RoutedEventArgs e)
        {
            int currentValue;
            if (int.TryParse(quantityTextBox.Text, out currentValue) && currentValue > 0)
            {
                currentValue--;
                quantityTextBox.Text = currentValue.ToString();
            }
        }
    }
}
