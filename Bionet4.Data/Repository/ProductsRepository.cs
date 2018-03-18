using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ProductsRepository : RepositoryBase<Product, int>, IProductsRepository
    {
        public ProductsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}