using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Models;

namespace OrderSystem.Interfaces
{
    public interface IReceiptGenerator
    {
        string GenerateReceipt(Order order, decimal discount, decimal finalAmount);
    }
}
