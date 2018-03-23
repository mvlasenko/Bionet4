using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class RajonsController : ApiController<Rajon, int>
    {
        public RajonsController() : base(DependencyResolver.Current.GetService<IRajonsRepository>())
        {

        }
    }
}