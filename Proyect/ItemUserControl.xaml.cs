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
    /// Логика взаимодействия для ItemUserControl.xaml
    /// </summary>
    public partial class ItemUserControl : UserControl
    {
        private Product product;
        public ItemUserControl(Product product)
        {
            InitializeComponent();
            this.product = product;
            ProductName = this.product.Name;
            ProductPrice = this.product.Price;
            ProductManufacturer = this.product.Manufacturer;
            ProductImageSource = new BitmapImage(new Uri(this.product.ImageData));
            ProductQuantity = this.product.Quantity;
        }

        public Product GetProduct()
        {
            return this.product;
        }

        public string ProductName
        {
            get { return productNameLabel.Text; }
            set
            {
                this.product.Name = value;
                productNameLabel.Text = value;
            }
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("ProductName", typeof(string), typeof(ItemUserControl));

        public int ProductQuantity
        {
            get { return int.Parse(quantityLabel.Text); }
            set
            {
                this.product.Quantity = value;
                quantityLabel.Text = value.ToString();
            }

        }

        public static readonly DependencyProperty Quantity =
            DependencyProperty.Register("ProductQuantity", typeof(int), typeof(ItemUserControl));
        public decimal ProductPrice
        {
            get { return decimal.Parse(productPriceLabel.Text); }
            set
            {
                this.product.Price = value;
                productPriceLabel.Text = value.ToString();
            }
        }

        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("ProductPrice", typeof(decimal), typeof(ItemUserControl));

        public string ProductManufacturer
        {
            get { return manufacturerLabel.Text; }
            set
            {
                this.product.Manufacturer = value;
                manufacturerLabel.Text = value;
            }
        }

        public static readonly DependencyProperty ManufacturerProperty =
            DependencyProperty.Register("ProductManufacturer", typeof(string), typeof(ItemUserControl));

        public ImageSource ProductImageSource
        {
            get { return productImage.Source; }
            set
            {
                this.product.ImageData = value.ToString();
                productImage.Source = value;
            }
        }

        public static readonly DependencyProperty ImagePathProperty =
            DependencyProperty.Register("ImagePath", typeof(string), typeof(ItemUserControl));
    }

}
