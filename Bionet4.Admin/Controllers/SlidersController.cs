using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class SlidersController : ApplicationController<Slider, int>
    {
        private ISlidersRepository repository;

        public SlidersController(ISlidersRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
