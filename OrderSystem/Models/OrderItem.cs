namespace OrderSystem.Models;

public class OrderItem
{
    public Product Product { get; }
    public int Quantity { get; }

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public decimal TotalPrice => Product.Price * Quantity;
}