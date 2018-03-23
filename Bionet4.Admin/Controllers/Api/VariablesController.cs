using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class VariablesController : ApiController<Variable, int>
    {
        public VariablesController() : base(DependencyResolver.Current.GetService<IVariablesRepository>())
        {

        }
    }
}