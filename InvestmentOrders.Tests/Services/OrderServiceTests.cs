using InvestmentOrders.Application.Const;
using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Application.Interfaces;
using InvestmentOrders.Application.Services;
using InvestmentOrders.Domain.Entities;
using InvestmentOrders.Domain.Exceptions;
using InvestmentOrders.Tests.Mocks;
using Moq;
using Xunit;

namespace InvestmentOrders.Tests.Services
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task CreateAsync_ShouldReturnOrderId()
        {
            // Arrange
            var orderRepo = OrderRepositoryMock.Create();

            var assetRepo = new Mock<IAssetRepository>();
            assetRepo.Setup(a => a.GetByIdAsync(10))
                .ReturnsAsync(new Asset
                {
                    Id = 10,
                    Name = "Test Asset",
                    AssetTypeId = AssetTypeIds.Accion,
                    Price = 100
                });

            var service = new OrderService(orderRepo.Object, assetRepo.Object);

            var request = new CreateOrderRequest
            {
                AccountId = 1,
                AssetId = 10,
                Quantity = 2
            };

            // Act
            var id = await service.CreateAsync(request);

            // Assert
            Assert.True(id >= 0);
        }

        [Fact]
        public async Task GetByIdAsync_WhenNotExists_ShouldReturnNull()
        {
            // Arrange
            var repo = OrderRepositoryMock.Create();
            var assetRepo = new Mock<IAssetRepository>();
            var service = new OrderService(repo.Object, assetRepo.Object);

            // Act
            var result = await service.GetByIdAsync(99);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateAsync_WithInvalidQuantity_ShouldThrow()
        {
            // Arrange
            var repo = OrderRepositoryMock.Create();

            var assetRepo = new Mock<IAssetRepository>();
            assetRepo.Setup(a => a.GetByIdAsync(10))
                .ReturnsAsync(new Asset
                {
                    Id = 10,
                    AssetTypeId = AssetTypeIds.Accion,
                    Price = 100
                });

            var service = new OrderService(repo.Object, assetRepo.Object);

            var request = new CreateOrderRequest
            {
                AccountId = 1,
                AssetId = 10,
                Quantity = 0
            };

            // Act + Assert
            await Assert.ThrowsAsync<DomainException>(
                () => service.CreateAsync(request)
            );
        }
    }
}