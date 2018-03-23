using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class OrderItemsRepository: RepositoryBase<OrderItem, int>, IOrderItemsRepository
    {
        public OrderItemsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}