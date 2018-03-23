using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class RajonsController : ApplicationController<Rajon, int>
    {
        private IRajonsRepository repository;

        public RajonsController(IRajonsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
