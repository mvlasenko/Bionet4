using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class UserRolesRepository: RepositoryBase<UserRole, int>, IUserRolesRepository
    {
        public UserRolesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}