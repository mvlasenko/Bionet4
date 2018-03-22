using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class CountriesController : ApiController<Country, int>
    {
        public CountriesController() : base(DependencyResolver.Current.GetService<ICountriesRepository>())
        {

        }
    }
}