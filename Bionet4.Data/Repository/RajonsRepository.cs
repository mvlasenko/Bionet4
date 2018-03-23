using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class RajonsRepository: RepositoryBase<Rajon, int>, IRajonsRepository
    {
        public RajonsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}