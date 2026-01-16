using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Application.Interfaces;
using InvestmentOrders.Domain.Entities;
using InvestmentOrders.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentOrders.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Order order)
        {
            Context.Orders.Add(order);
            await Context.SaveChangesAsync();
        }

        public async Task<OrderDetailsDto?> GetAsync(int id)
        {
            return await Context.Orders
                .AsNoTracking()
                .Where(o => o.Id == id)
                .Select(o => new OrderDetailsDto
                {
                    Id = o.Id,
                    AccountId = o.AccountId,

                    AssetId = o.AssetId,
                    AssetName = o.Asset.Name,
                    AssetType = o.Asset.AssetType.Description,

                    Quantity = o.Quantity,
                    Price = o.Price,

                    StatusId = o.StatusId,
                    StatusDescription = o.Status.Description,

                    TotalAmount = o.TotalAmount
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Order order)
        {
            Context.Orders.Update(order);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Order order)
        {
            Context.Orders.Remove(order);
            await Context.SaveChangesAsync();
        }
    }
}
