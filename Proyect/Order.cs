using Proyect;
using System.Collections.Generic;

public class Order
{
    private static int nextOrderId = 1;
    public string UserLogin { get; set; }
    public List<CartProduct> CartProducts { get; set; }
    public string Status { get; set; }
    public int OrderId { get; set; }

    public Order(string userLogin, List<CartProduct> cartProducts) : this()
    {
        this.UserLogin = userLogin;
        this.CartProducts = cartProducts;
        this.Status = "waiting";
    }

    public Order()
    {
        this.OrderId = GetNextOrderId();
    }

    public void Accept()
    {
        this.Status = "accept";
    }

    public void Decline()
    {
        this.Status = "decline";
    }

    private int GetNextOrderId()
    {
        return nextOrderId++;
    }

    public static void SetNextOrderId(int value)
    {
        nextOrderId = value;
    }
}
