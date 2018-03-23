using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ProductsForOrderRepository: RepositoryBase<ProductForOrder, int>, IProductsForOrderRepository
    {
        public ProductsForOrderRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}