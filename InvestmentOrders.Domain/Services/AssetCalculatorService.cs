using InvestmentOrders.Domain.Calculators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentOrders.Domain.Services
{
    public static class AssetCalculatorService
    {
        public static decimal CalculateTotal(
            int assetTypeId,
            decimal price,
            int quantity)
        {
            var calculator = AssetCalculatorFactory.GetCalculator(assetTypeId);
            return calculator.Calculate(price, quantity);
        }
    }
}
