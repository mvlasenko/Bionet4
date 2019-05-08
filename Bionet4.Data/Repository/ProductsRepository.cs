using System.Collections.Generic;
using System.Linq;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ProductsRepository: RepositoryBase<Product, int>, IProductsRepository
    {
        public ProductsRepository(IDbContextFactory factory) : base(factory)
        {
        }

        public List<int?> GetCategoriesNonEmpty()
        {
            return this.DbSet.GroupBy(p => p.CategoryId).Select(g => new { CategoryId = g.Key, Count = g.Count() }).Where(g => g.Count > 0).Select(g => g.CategoryId).ToList();
        }

    }
}