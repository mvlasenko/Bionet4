using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class UserClaimsController : ApplicationController<UserClaim, int>
    {
        private IUserClaimsRepository repository;

        public UserClaimsController(IUserClaimsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
