using InvestmentOrders.Application.Const;
using InvestmentOrders.Domain.Entities;

namespace InvestmentOrders.Tests.Builders
{
    public static class OrderBuilder
    {
        public static Order Build()
        {
            return Order.Create(
                accountId: 1,
                assetId: 10,
                quantity: 5,
                price: 100,
                totalAmount: 500,
                statusId: OrderStatusIds.EnProceso
            );
        }
    }
}