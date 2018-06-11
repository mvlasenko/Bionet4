using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class AgentsController : ApplicationController<Agent, int>
    {
        private IAgentsRepository repository;

        public AgentsController(IAgentsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
