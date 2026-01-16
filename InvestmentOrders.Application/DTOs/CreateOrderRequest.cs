using System.ComponentModel.DataAnnotations;

namespace InvestmentOrders.Application.DTOs
{
    public class CreateOrderRequest
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AccountId debe ser mayor que 0")]
        public int AccountId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "AssetId debe ser mayor que 0")]
        public int AssetId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity debe ser mayor que 0")]
        public int Quantity { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price debe ser mayor que 0")]
        public decimal? Price { get; set; }
    }
}
