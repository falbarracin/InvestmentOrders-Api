using System;
using InvestmentOrders.Domain.Calculators;

namespace InvestmentOrders.Domain.Calculators
{
    public static class AssetCalculatorFactory
    {
        public static IAssetCalculator GetCalculator(int assetTypeId)
        {
            return assetTypeId switch
            {
                1 => new ActionCalculator(), // Acción
                2 => new BondCalculator(),   // Bono
                3 => new FciCalculator(),    // FCI
                _ => throw new ArgumentException("Tipo de activo inválido")
            };
        }
    }
}
