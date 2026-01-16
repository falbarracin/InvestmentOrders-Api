namespace InvestmentOrders.Domain.Calculators
{
    public class FciCalculator : IAssetCalculator
    {
        public decimal Calculate(decimal price, int quantity)
        {
            return price * quantity;
        }
    }
}
