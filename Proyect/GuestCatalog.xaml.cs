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
    /// Логика взаимодействия для GuestCatalog.xaml
    /// </summary>
    public partial class GuestCatalog : Window
    {
        private List<Product> products;
        public GuestCatalog()
        {
            InitializeComponent();
            products = DataRepository.LoadProducts();

            productListView.Items.Clear();

            foreach (var product in products)
            {
                var item = new ItemUserControl(product);
                productListView.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
