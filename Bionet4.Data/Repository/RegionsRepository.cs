using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class RegionsRepository: RepositoryBase<Region, int>, IRegionsRepository
    {
        public RegionsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}