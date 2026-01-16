namespace InvestmentOrders.Domain.Calculators
{
    public class ActionCalculator : IAssetCalculator
    {
        public decimal Calculate(decimal price, int quantity)
        {
            var baseAmount = price * quantity;
            var commission = baseAmount * 0.006m;
            var tax = commission * 0.21m;
            return baseAmount + commission + tax;
        }
    }
}
