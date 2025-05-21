using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystem.Interfaces;

namespace OrderSystem.Services
{
    public class FixedAmountDiscount : IDiscountStrategy
    {
        private readonly decimal _amount;

        public FixedAmountDiscount(decimal amount)
        {
            _amount = amount;
        }

        public decimal ApplyDiscount(decimal totalAmount)
        {
            return Math.Max(0, totalAmount - _amount);
        }
    }
}
