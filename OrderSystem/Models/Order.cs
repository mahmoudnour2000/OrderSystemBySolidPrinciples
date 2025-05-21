using System.Collections.Generic;
using System.Linq;

namespace OrderSystem.Models;

public class Order
{
    public List<OrderItem> Items { get; } = new List<OrderItem>();
    public decimal TotalAmount => Items.Sum(item => item.TotalPrice);
}