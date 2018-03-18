using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class IngredientsRepository : RepositoryBase<Ingredient, int>, IIngredientsRepository
    {
        public IngredientsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}