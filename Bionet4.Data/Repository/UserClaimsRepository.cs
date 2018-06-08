using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class UserClaimsRepository: RepositoryBase<UserClaim, int>, IUserClaimsRepository
    {
        public UserClaimsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}