using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class LogosRepository: RepositoryBase<Logo, int>, ILogosRepository
    {
        public LogosRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}