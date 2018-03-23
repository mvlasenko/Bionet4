using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class AgentsController : ApiController<Agent, int>
    {
        public AgentsController() : base(DependencyResolver.Current.GetService<IAgentsRepository>())
        {

        }
    }
}