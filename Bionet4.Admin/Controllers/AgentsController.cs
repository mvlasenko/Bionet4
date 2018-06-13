using System;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class AgentsController : ApplicationController<Agent, int>
    {
        private IAgentsRepository repository;

        public AgentsController(IAgentsRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ActionResult CreatePartial()
        {
            Agent entity = new Agent();
            entity.BeginDate = DateTime.Now;

            return PartialView("_CreatePartial", entity);
        }

        public override ActionResult UpdatePartial(int id, Agent entity)
        {
            entity.UpdatedDateTime = DateTime.Now;
            return base.UpdatePartial(id, entity);
        }
    }
}
