using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class RegionsController : ApplicationController<Region, int>
    {
        private IRegionsRepository repository;

        public RegionsController(IRegionsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
