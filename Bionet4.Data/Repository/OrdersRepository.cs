using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class OrdersRepository: RepositoryBase<Order, int>, IOrdersRepository
    {
        public OrdersRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}