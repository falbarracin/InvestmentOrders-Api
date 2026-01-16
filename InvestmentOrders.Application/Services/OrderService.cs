using InvestmentOrders.Application.Const;
using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Application.Exceptions;
using InvestmentOrders.Application.Interfaces;
using InvestmentOrders.Domain.Calculators;
using InvestmentOrders.Domain.Entities;

namespace InvestmentOrders.Application.Services
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepo;
        private readonly IAssetRepository _assetRepo;

        public OrderService(IOrderRepository orderRepo, IAssetRepository assetRepo)
        {
            _orderRepo = orderRepo;
            _assetRepo = assetRepo;
        }

        public async Task<int> CreateAsync(CreateOrderRequest request)
        {
            if (request.Quantity <= 0)
                throw new BusinessException("La cantidad debe ser mayor a 0");

            var asset = await _assetRepo.GetByIdAsync(request.AssetId);
            if (asset == null)
                throw new NotFoundException("Activo no encontrado");

            decimal price;

            // Acción precio desde BBDD
            if (asset.AssetTypeId == AssetTypeIds.Accion)
            {
                price = asset.Price;
            }
            else
            {
                // Bono / FCI precio desde request
                if (!request.Price.HasValue || request.Price <= 0)
                    throw new BusinessException("Precio requerido y mayor a 0");

                price = request.Price.Value;
            }

            var calculator = AssetCalculatorFactory.GetCalculator(asset.AssetTypeId);
            var totalAmount = calculator.Calculate(price, request.Quantity);

            var order = Order.Create(
                request.AccountId,
                asset.Id,
                request.Quantity,
                price,
                totalAmount,
                OrderStatusIds.EnProceso
            );

            await _orderRepo.AddAsync(order);

            return order.Id;
        }

        public async Task<OrderResponse?> GetByIdAsync(int id)
        {
            var details = await _orderRepo.GetAsync(id);

            if (details == null)
                return null;

            return new OrderResponse
            {
                Id = details.Id,
                AccountId = details.AccountId,

                AssetId = details.AssetId,
                AssetName = details.AssetName,
                AssetType = details.AssetType,

                Quantity = details.Quantity,
                Price = details.Price ?? 0m,

                StatusId = details.StatusId,
                StatusDescription = details.StatusDescription,

                TotalAmount = details.TotalAmount
            };
        }
    }
}
