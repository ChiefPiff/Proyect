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
    /// Логика взаимодействия для AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {
        public AddCategoryWindow()
        {
            InitializeComponent();
        }

        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {
            string name = categoryNameTextBox.Text;

            Category newCategory = new Category
            {
                Name = name
            };

            //DataRepository.AddCategory(newCategory);
            DialogResult = true;
            Close();
        }
    }
}
