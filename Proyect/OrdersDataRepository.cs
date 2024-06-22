using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.IO;


namespace Proyect
{
    public class OrdersDataRepository
    {
        private static string orderDataFile = "orders.json";
        public static List<Order> LoadOrders()
        {
            if (File.Exists(orderDataFile))
            {
                string jsonData = File.ReadAllText(orderDataFile);
                if (jsonData == "")
                {
                    return new List<Order>();
                }
                List<Order> orders = JsonSerializer.Deserialize<List<Order>>(jsonData);

                // Найти максимальное значение ProductId
                int maxOrderId = orders.Count > 0 ? orders.Max(order => order.OrderId) : 0;

                // Установить следующее значение nextProductId
                int nextOrderId = maxOrderId + 1;
                Order.SetNextOrderId(nextOrderId);

                return orders;
            }
            return new List<Order>();
        }


        public static void SaveOrder(List<Order> orders)
        {
            string jsonData = JsonSerializer.Serialize(orders);
            File.WriteAllText(orderDataFile, jsonData);
        }

        public static void AddOrder(Order order)
        {
            List<Order> orders = LoadOrders();
            orders.Add(order);
            SaveOrder(orders);
        }

        public static void SetOrderStatus(int orderId, string status)
        {
            List<Order> orders = LoadOrders(); // Загрузка списка продуктов

            Order existingOrder = orders.FirstOrDefault(order => order.OrderId == orderId);

            if (existingOrder != null)
            {
                existingOrder.Status = status;

                SaveOrder(orders);
                MessageBox.Show("Статус заказ обновлён.");
            }
            else
            {
                MessageBox.Show($"Заказ не найден.");
            }
        }
    }
}
