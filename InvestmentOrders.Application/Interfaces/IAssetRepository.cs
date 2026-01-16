using InvestmentOrders.Domain.Entities;

namespace InvestmentOrders.Application.Interfaces
{
    public interface IAssetRepository
    {
        /// <summary>
        /// Mpetodo que obtiene una orden por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Asset?> GetByIdAsync(int id);
    }
}
