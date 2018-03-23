using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class VariablesController : ApplicationController<Variable, int>
    {
        private IVariablesRepository repository;

        public VariablesController(IVariablesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
