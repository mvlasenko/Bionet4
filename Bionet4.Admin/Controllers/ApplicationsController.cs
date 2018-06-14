using System;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ApplicationsController : ApplicationController<Application, int>
    {
        private IApplicationsRepository repository;

        public ApplicationsController(IApplicationsRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ActionResult CreatePartial()
        {
            Application entity = new Application();
            entity.BirthDate = new DateTime(DateTime.Now.Year - 40, 1, 1);

            return PartialView("_CreatePartial", entity);
        }

        public override ActionResult CreatePartial(Application entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            entity.CityType = 0;
            return base.CreatePartial(entity);
        }
    }
}
