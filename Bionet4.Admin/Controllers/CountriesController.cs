using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class CountriesController : ApplicationController<Country, int>
    {
        private ICountriesRepository repository;

        public CountriesController(ICountriesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

