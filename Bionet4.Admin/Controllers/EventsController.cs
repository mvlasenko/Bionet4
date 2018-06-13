using System;
using System.Web.Mvc;
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

        public override ActionResult CreatePartial()
        {
            Event entity = new Event();
            entity.EventDateTime = DateTime.Now;

            return PartialView("_CreatePartial", entity);
        }

        public override ActionResult CreatePartial(Event entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }
    }
}
