using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class UnitsRepository: RepositoryBase<Unit, int>, IUnitsRepository
    {
        public UnitsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}