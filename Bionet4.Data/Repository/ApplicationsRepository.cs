using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ApplicationsRepository: RepositoryBase<Application, int>, IApplicationsRepository
    {
        public ApplicationsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}