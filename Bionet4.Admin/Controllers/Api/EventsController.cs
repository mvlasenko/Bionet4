using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class EventsController : ApiController<Event, int>
    {
        public EventsController() : base(DependencyResolver.Current.GetService<IEventsRepository>())
        {

        }
    }
}