using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class VariablesRepository: RepositoryBase<Variable, int>, IVariablesRepository
    {
        public VariablesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}