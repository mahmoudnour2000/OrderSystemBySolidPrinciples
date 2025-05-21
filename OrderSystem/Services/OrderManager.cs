using System;
using System.Collections.Generic;
using System.Linq;
using OrderSystem.Interfaces;
using OrderSystem.Models;

namespace OrderSystem.Services;

public class OrderManager
{
    private readonly IDiscountStrategy _discountStrategy;
    private readonly IReceiptGenerator _receiptGenerator;
    private readonly List<Product> _products;

    public OrderManager(IDiscountStrategy discountStrategy, IReceiptGenerator receiptGenerator)
    {
        _discountStrategy = discountStrategy;
        _receiptGenerator = receiptGenerator;
        _products = new List<Product>
        {
            new Product(1, "لاب توب", 999.99m),
            new Product(2, "ماوس", 29.99m),
            new Product(3, "كيبورد", 59.99m)
        };
    }

    public void Run()
    {
        var order = new Order();
        while (true)
        {
            Console.WriteLine("\nالمنتجات المتاحة:");
            foreach (var p in _products)
            {
                Console.WriteLine($"{p.Id}. {p.Name} - ${p.Price:F2}");
            }
            Console.WriteLine("أدخل رقم المنتج (أو 0 للإنهاء): ");
            if (!int.TryParse(Console.ReadLine(), out int productId) || productId == 0)
                break;

            var product = _products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
            {
                Console.WriteLine("رقم المنتج غير صحيح.");
                continue;
            }

            Console.WriteLine($"أدخل الكمية لـ {product.Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("الكمية غير صحيحة.");
                continue;
            }

            order.Items.Add(new OrderItem(product, quantity));
        }

        if (order.Items.Count == 0)
        {
            Console.WriteLine("لا يوجد منتجات في الطلب.");
            return;
        }

        decimal totalAmount = order.TotalAmount;
        decimal finalAmount = _discountStrategy.ApplyDiscount(totalAmount);
        decimal discount = totalAmount - finalAmount;

        string receipt = _receiptGenerator.GenerateReceipt(order, discount, finalAmount);
        Console.WriteLine("\n" + receipt);
    }
}
