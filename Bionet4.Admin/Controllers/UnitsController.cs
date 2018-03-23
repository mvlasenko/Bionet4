using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class UnitsController : ApplicationController<Unit, int>
    {
        private IUnitsRepository repository;

        public UnitsController(IUnitsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
