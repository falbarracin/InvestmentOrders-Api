using InvestmentOrders.Domain.Exceptions;

namespace InvestmentOrders.Domain.Entities
{
    public class Order
    {
        public int Id { get; private set; }
        public int AccountId { get; private set; }

        public int AssetId { get; private set; }
        public Asset Asset { get; private set; } = null!;

        public int Quantity { get; private set; }
        public decimal? Price { get; private set; }

        public int StatusId { get; private set; }
        public OrderStatus Status { get; private set; } = null!;

        public decimal TotalAmount { get; private set; }

        private Order() { }

        public static Order Create(
            int accountId,
            int assetId,
            int quantity,
            decimal? price,
            decimal totalAmount,
            int statusId)
        {
            if (quantity <= 0)
                throw new DomainException("La cantidad debe ser mayor a cero");

            if (totalAmount <= 0)
                throw new DomainException("El monto total debe ser mayor a cero");

            return new Order
            {
                AccountId = accountId,
                AssetId = assetId,
                Quantity = quantity,
                Price = price,
                StatusId = statusId,
                TotalAmount = totalAmount
            };
        }

        public void ChangeStatus(int statusId)
        {
            StatusId = statusId;
        }
    }
}
