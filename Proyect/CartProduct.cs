using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect
{
    public class CartProduct
    {
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public string ImageData { get; set; }
        public bool RecipeIsNeeded { get; set; }
        public string RecipeImageData { get; set; }

        public CartProduct(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Category = product.Category;
            Price = product.Price;
            Quantity = product.Quantity;
            Manufacturer = product.Manufacturer;
            ImageData = product.ImageData;
            RecipeIsNeeded = product.RecipeIsNeeded;
            RecipeImageData = "";
        }

        public CartProduct()
        {

        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Product other = (Product)obj;
            return ProductId == other.ProductId && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductId, Name);
        }

    }
}
