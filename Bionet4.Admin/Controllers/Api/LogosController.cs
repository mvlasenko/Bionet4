using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class LogosController : ApiController<Logo, int>
    {
        public LogosController() : base(DependencyResolver.Current.GetService<ILogosRepository>())
        {

        }
    }
}