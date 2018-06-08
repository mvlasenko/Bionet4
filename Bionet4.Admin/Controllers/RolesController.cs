using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class RolesController : ApplicationController<Role, string>
    {
        private IRolesRepository repository;

        public RolesController(IRolesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
