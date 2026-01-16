namespace InvestmentOrders.Application.DTOs
{
    public class OrderDetailsDto
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        // Asset
        public int AssetId { get; set; }
        public string AssetName { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;

        // Order data
        public int Quantity { get; set; }
        public decimal? Price { get; set; }

        // Status
        public int StatusId { get; set; }
        public string StatusDescription { get; set; } = string.Empty;

        public decimal TotalAmount { get; set; }
    }
}
