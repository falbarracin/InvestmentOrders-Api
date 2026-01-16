using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrders.Domain.Calculators
{
    public class BondCalculator : IAssetCalculator
    {
        public decimal Calculate(decimal price, int quantity)
        {
            var baseAmount = price * quantity;
            var commission = baseAmount * 0.002m;
            var tax = commission * 0.21m;
            return baseAmount + commission + tax;
        }
    }
}
