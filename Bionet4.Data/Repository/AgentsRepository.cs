using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class AgentsRepository: RepositoryBase<Agent, int>, IAgentsRepository
    {
        public AgentsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}