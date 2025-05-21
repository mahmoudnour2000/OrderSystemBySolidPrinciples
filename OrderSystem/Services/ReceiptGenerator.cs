using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Interfaces;
using OrderSystem.Models;

namespace OrderSystem.Services
{
    public class ReceiptGenerator : IReceiptGenerator
    {
        public string GenerateReceipt(Order order, decimal discount, decimal finalAmount)
        {
            var receipt = "===== الفاتورة =====\n";
            receipt += "المنتجات:\n";
            foreach (var item in order.Items)
            {
                receipt += $"- {item.Product.Name} (x{item.Quantity}): ${item.TotalPrice:F2}\n";
            }
            receipt += $"المجموع الفرعي: ${order.TotalAmount:F2}\n";
            receipt += $"الخصم: ${discount:F2}\n";
            receipt += $"المجموع النهائي: ${finalAmount:F2}\n";
            receipt += "==================";
            return receipt;
        }
    }
}
