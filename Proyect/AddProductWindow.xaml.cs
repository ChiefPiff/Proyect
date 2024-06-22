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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        string imagePath;
        bool recipeIsNeeded;
        public AddProductWindow()
        {
            InitializeComponent();
            recipeIsNeeded = false;

        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = productNameTextBox.Text;
            decimal price = decimal.Parse(productPriceTextBox.Text);
            string manufacturer = productManufacturerTextBox.Text;
            int.TryParse(quantityTextBox.Text, out int quantity);

            Product newProduct = new Product
            (
                name,
                null,
                price,
                quantity,
                manufacturer,
                productImage.Source.ToString(),
                recipeIsNeeded

            );

            DataRepository.AddProduct(newProduct);
            DialogResult = true;
            Close();
        }

        private void selectProductImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Изображения (*.jpg, *.png)|*.jpg;*.png",
                Title = "Выберите изображение товара"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string imagePath = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(imagePath);
                bitmapImage.EndInit();
                productImage.Source = bitmapImage;
            }
        }

        private void incraseButton_Click(object sender, RoutedEventArgs e)
        {
            int currentValue;
            if (int.TryParse(quantityTextBox.Text, out currentValue))
            {
                currentValue++;
                quantityTextBox.Text = currentValue.ToString();
            }
        }

        private void decreaseButton_Click(object sender, RoutedEventArgs e)
        {
            int currentValue;
            if (int.TryParse(quantityTextBox.Text, out currentValue) && currentValue > 0)
            {
                currentValue--;
                quantityTextBox.Text = currentValue.ToString();
            }
        }

        private void recipeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            recipeIsNeeded = false;
        }

        private void recipeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            recipeIsNeeded = true;
        }
    }
}
