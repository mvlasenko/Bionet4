using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class UserRolesController : ApplicationController<UserRole, int>
    {
        private IUserRolesRepository repository;

        public UserRolesController(IUserRolesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
