using InvestmentOrders.Application.DTOs;
using InvestmentOrders.Domain.Entities;

namespace InvestmentOrders.Application.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
        Task<OrderDetailsDto?> GetAsync(int id);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Order order);
    }
}
