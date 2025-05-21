using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Interfaces;

namespace OrderSystem.Services
{
    public class NoDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalAmount)
        {
            return totalAmount;
        }
    }
}
