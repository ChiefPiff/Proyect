using System;

public class Product 
{
    private static int nextProductId = 1;

    public int ProductId { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Manufacturer { get; set; }
    public string ImageData { get; set; }

    public bool RecipeIsNeeded {  get; set; }

    public Product()
    {
        ProductId = GetNextProductId();
    }

    public Product(string name, Category category, decimal price, int quantity, string manufacturer, string imageData, bool recipeIsNeeded)
        : this()
    {
        Name = name;
        Category = category;
        Price = price;
        Quantity = quantity;
        Manufacturer = manufacturer;
        ImageData = imageData;
        RecipeIsNeeded = recipeIsNeeded;
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

    private static int GetNextProductId()
    {
        return nextProductId++;
    }


    public static void SetNextProductId(int value)
    {
        nextProductId = value;
    }
}