namespace InvestmentOrders.Application.DTOs
{
    public class OrderResponse
    {
        public int Id { get; init; }

        // Cuenta
        public int AccountId { get; init; }

        // Activo
        public int AssetId { get; init; }
        public string AssetName { get; init; } = string.Empty;
        public string AssetType { get; init; } = string.Empty;

        // Orden
        public int Quantity { get; init; }
        public decimal Price { get; init; }

        // Estado
        public int StatusId { get; init; }
        public string StatusDescription { get; init; } = string.Empty;

        public decimal TotalAmount { get; init; }
    }
}
