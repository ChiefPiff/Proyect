using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System;
using System.IO;
using System.Linq;

public partial class DataRepository
{
    //private static string categoryDataFile = "categories.json";
    private static string productDataFile = "products.json";

    //public static List<Category> LoadCategories()
    //{
    //    if (File.Exists(categoryDataFile))
    //    {
    //        string jsonData = File.ReadAllText(categoryDataFile);
    //        return JsonSerializer.Deserialize<List<Category>>(jsonData);
    //    }
    //    return new List<Category>();
    //}

    //public static void SaveCategories(List<Category> categories)
    //{
    //    string jsonData = JsonSerializer.Serialize(categories);
    //    File.WriteAllText(categoryDataFile, jsonData);
    //}

    public static List<Product> LoadProducts()
    {
        if (File.Exists(productDataFile))
        {
            string jsonData = File.ReadAllText(productDataFile);
            if (jsonData == "")
            {
                return new List<Product>();
            }
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(jsonData);

            // Найти максимальное значение ProductId
            int maxProductId = products.Count > 0 ? products.Max(p => p.ProductId) : 0;

            // Установить следующее значение nextProductId
            int nextProductId = maxProductId + 1;
            Product.SetNextProductId(nextProductId);

            return products;
        }
        return new List<Product>();
    }


    public static void SaveProducts(List<Product> products)
    {
        string jsonData = JsonSerializer.Serialize(products);
        File.WriteAllText(productDataFile, jsonData);
    }

    public static void AddProduct(Product product)
    {
        List<Product> products = LoadProducts();
        products.Add(product);
        SaveProducts(products);
    }

    public static void UpdateProduct(Product product)
    {
        List<Product> products = LoadProducts(); // Загрузка списка продуктов

        Console.WriteLine("Loaded products:");
        foreach (var p in products)
        {
            Console.WriteLine($"ProductId: {p.ProductId}, Name: {p.Name}");
        }

        Product existingProduct = products.FirstOrDefault(p => p.ProductId == product.ProductId);

        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            existingProduct.Manufacturer = product.Manufacturer;
            existingProduct.ImageData = product.ImageData;

            SaveProducts(products);
            MessageBox.Show("Продукт успешно обновлен.");
        }
        else
        {
            MessageBox.Show($"Продукт с ID {product.ProductId} не найден в списке.");
        }
    }



    //public static void AddCategory(Category category)
    //{
    //    List<Category> categories = LoadCategories();
    //    categories.Add(category);
    //    SaveCategories(categories);
    //}

    //public static void UpdateCategory(Category category)
    //{
    //    List<Category> categories = LoadCategories();
    //    int index = categories.FindIndex(c => c.CategoryId == category.CategoryId);
    //    if (index >= 0)
    //    {
    //        categories[index] = category;
    //        SaveCategories(categories);
    //    }
    //}
}
