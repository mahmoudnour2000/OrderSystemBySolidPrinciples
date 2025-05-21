using System;
using OrderSystem.Interfaces;
using OrderSystem.Services;

namespace OrderSystem;

class Program
{
    static void Main(string[] args)
    {
        // Dependency Injection
        IDiscountStrategy discountStrategy = new PercentageDiscount(10); // خصم 10%
        // IDiscountStrategy discountStrategy = new FixedAmountDiscount(50); // خصم ثابت 50
        // IDiscountStrategy discountStrategy = new NoDiscount(); // بدون خصم
        IReceiptGenerator receiptGenerator = new ReceiptGenerator();

        var orderManager = new OrderManager(discountStrategy, receiptGenerator);
        orderManager.Run();
    }
}
