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
    /// Логика взаимодействия для AddRecipeWindow.xaml
    /// </summary>
    public partial class AddRecipeWindow : Window
    {
        private CartProduct cartProduct;
        public AddRecipeWindow(ref CartProduct cartProduct)
        {

            InitializeComponent();
            this.cartProduct = cartProduct;
            sendRecipeImageButton.IsEnabled = false;
        }

        private void selectRecipeImageButton_Click(object sender, RoutedEventArgs e)
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
                recipeImage.Source = bitmapImage;
                sendRecipeImageButton.IsEnabled = true;
            }
        }

        private void sendRecipeImageButton_Click(object sender, RoutedEventArgs e)
        {
            this.cartProduct.RecipeImageData = recipeImage.Source.ToString();
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
