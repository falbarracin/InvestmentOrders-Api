using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Application.Interfaces;
using InvestmentOrders.Domain.Entities;
using Moq;

namespace InvestmentOrders.Tests.Mocks
{
    public static class OrderRepositoryMock
    {
        public static Mock<IOrderRepository> Create()
        {
            var mock = new Mock<IOrderRepository>();

            mock.Setup(r => r.AddAsync(It.IsAny<Order>()))
                .Returns(Task.CompletedTask);

            mock.Setup(r => r.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((OrderDetailsDto?)null);

            return mock;
        }
    }
}