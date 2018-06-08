using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class UserLoginsRepository: RepositoryBase<UserLogin, int>, IUserLoginsRepository
    {
        public UserLoginsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}