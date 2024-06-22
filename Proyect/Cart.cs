using System.Collections.Generic;
public class Cart
{
    public bool itsOk = false;
    public bool quantityIncrase = false;
    public List<Product> Items { get; private set; }

    public Cart()
    {
        Items = new List<Product>();
    }

    //public void AddItemToCart(string name, string price, string manufacturer, string imageData, string quantity)
    //{
    //    ItemUserControl item = new ItemUserControl(name, price, manufacturer, imageData, quantity);

    //}

    public void AddToCart(Product product)
    {
        int quantityty = product.Quantity;
        Product existingProduct = Items.Find(p => p.ProductId == product.ProductId);

        if (existingProduct == null)
        {
            Items.Add(product);
            itsOk = true;

        }
        else
        {
            existingProduct.Quantity++;
            if (product.Quantity != quantityty)
            {
                quantityIncrase = true;
            }
        }
    }

    public void RemoveFromCart(Product product)
    {
        Product existingProduct = Items.Find(p => p.ProductId == product.ProductId);

        if (existingProduct != null)
        {
            existingProduct.Quantity--;

            if (existingProduct.Quantity == 0)
            {
                Items.Remove(existingProduct);
            }
        }
    }

    public void Checkout()
    {

    }
}
