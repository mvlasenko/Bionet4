using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class RegionsController : ApiController<Region, int>
    {
        public RegionsController() : base(DependencyResolver.Current.GetService<IRegionsRepository>())
        {

        }
    }
}