using InvestmentOrders.Application.Interfaces;
using InvestmentOrders.Domain.Entities;
using InvestmentOrders.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace InvestmentOrders.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly AppDbContext _context;

        public AssetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _context.Assets.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
