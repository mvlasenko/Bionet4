using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class RolesRepository: RepositoryBase<Role, string>, IRolesRepository
    {
        public RolesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}