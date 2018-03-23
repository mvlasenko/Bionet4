using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class EventsController : ApplicationController<Event, int>
    {
        private IEventsRepository repository;

        public EventsController(IEventsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
