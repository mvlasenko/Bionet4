using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class UserLoginsController : ApplicationController<UserLogin, int>
    {
        private IUserLoginsRepository repository;

        public UserLoginsController(IUserLoginsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
