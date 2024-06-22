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
    /// Логика взаимодействия для CartUserControl.xaml
    /// </summary>
    public partial class CartUserControl : UserControl
    {
        private CartProduct cartProduct;
        int currentValue = 1;
        public CartUserControl(CartProduct cartProduct)
        {

            InitializeComponent();
            this.cartProduct = cartProduct;
            ProductName = this.cartProduct.Name;
            ProductPrice = this.cartProduct.Price;
            ProductManufacturer = this.cartProduct.Manufacturer;
            ProductImageSource = new BitmapImage(new Uri(this.cartProduct.ImageData));
            ProductQuantity = this.cartProduct.Quantity;
            ProductRecipeNeeded = this.cartProduct.RecipeIsNeeded;
            string recipeImageData = this.CartProduct.RecipeImageData;
            if (recipeImageData != "")
            {
                ProductRecipeImageData = new BitmapImage(new Uri(this.cartProduct.RecipeImageData));
            }
            
        }

        public CartProduct CartProduct
        {
            get { return this.cartProduct; }
        }

        public string ProductName
        {
            get { return productNameLabel.Text; }
            set
            {
                this.cartProduct.Name = value;
                productNameLabel.Text = value;
            }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("ProductName", typeof(string), typeof(CartUserControl));

        public int ProductInCartQuantity
        {
            get { return int.Parse(quantityLabel.Text); }
            set { quantityLabel.Text = value.ToString(); }
        }
        public static readonly DependencyProperty CartQuantity =
            DependencyProperty.Register("ProductInCartQuantity", typeof(int), typeof(CartUserControl));

        public int ProductQuantity
        {
            get { return int.Parse(quantityLabel.Text); }
            set
            {
                this.cartProduct.Quantity = value;
                quantityLabel.Text = value.ToString();
            }

        }
        public static readonly DependencyProperty Quantity =
            DependencyProperty.Register("ProductQuantity", typeof(int), typeof(CartUserControl));
        public decimal ProductPrice
        {
            get { return decimal.Parse(productPriceLabel.Text); }
            set
            {
                this.cartProduct.Price = value;
                productPriceLabel.Text = value.ToString();
            }
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("ProductPrice", typeof(decimal), typeof(CartUserControl));

        public string ProductManufacturer
        {
            get { return manufacturerLabel.Text; }
            set
            {
                this.cartProduct.Manufacturer = value;
                manufacturerLabel.Text = value;
            }
        }
        public static readonly DependencyProperty ManufacturerProperty =
            DependencyProperty.Register("ProductManufacturer", typeof(string), typeof(CartUserControl));

        public ImageSource ProductImageSource
        {
            get { return productImage.Source; }
            set
            {
                this.cartProduct.ImageData = value.ToString();
                productImage.Source = value;
            }
        }

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(CartUserControl));

        public bool ProductRecipeNeeded
        {
            get { return cartProduct.RecipeIsNeeded; }
            set
            {
                this.cartProduct.RecipeIsNeeded = value;
                if (value)
                {
                    recipeNeedLabel.Text = "Требуется рецепт";
                }
                else
                {
                    recipeNeedLabel.Text = "Рецепт не требуется";
                }
            }
        }

        public static readonly DependencyProperty RecipeNeededProperty =
            DependencyProperty.Register("RecipeNeeded", typeof(bool), typeof(CartUserControl));

        public ImageSource ProductRecipeImageData
        {
            get { return recipeImage.Source; }
            set
            {
                this.cartProduct.RecipeImageData = value.ToString();
                recipeImage.Source = value;
            }
        }

        public static readonly DependencyProperty RecipeImagePathProperty =
            DependencyProperty.Register("RecipeImagePath", typeof(bool), typeof(CartUserControl));

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(cartQuantityLabel.Text, out currentValue))
            {
                currentValue++;
                cartQuantityLabel.Text = currentValue.ToString();
            }
        }

        private void DecreaseButton_Click_1(object sender, RoutedEventArgs e)
        {

            if (int.TryParse(cartQuantityLabel.Text, out currentValue) && currentValue > 0)
            {
                currentValue--;
                cartQuantityLabel.Text = currentValue.ToString();
            }
        }
    }
}
