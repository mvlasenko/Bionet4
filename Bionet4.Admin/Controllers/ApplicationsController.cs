using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ApplicationsController : ApplicationController<Application, int>
    {
        private IApplicationsRepository repository;

        public ApplicationsController(IApplicationsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
