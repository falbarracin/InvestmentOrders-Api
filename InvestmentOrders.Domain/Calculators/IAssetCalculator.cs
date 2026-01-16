namespace InvestmentOrders.Domain.Calculators
{
    public interface IAssetCalculator
    {
        decimal Calculate(decimal price, int quantity);
    }
}
