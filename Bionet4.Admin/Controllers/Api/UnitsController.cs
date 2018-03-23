using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class UnitsController : ApiController<Unit, int>
    {
        public UnitsController() : base(DependencyResolver.Current.GetService<IUnitsRepository>())
        {

        }
    }
}