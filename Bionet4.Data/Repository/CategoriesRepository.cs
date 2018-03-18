using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class CategoriesRepository: RepositoryBase<Category, int>, ICategoriesRepository
    {
        public CategoriesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}