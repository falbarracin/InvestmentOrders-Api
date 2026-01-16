using InvestmentOrders.Infrastructure.Persistence;

namespace InvestmentOrders.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly AppDbContext Context;

        protected RepositoryBase(AppDbContext context)
        {
            Context = context;
        }
    }
}
