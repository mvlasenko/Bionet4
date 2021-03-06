using System;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class FAQController : ApplicationController<FAQ, int>
    {
        private IFAQRepository repository;

        public FAQController(IFAQRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ActionResult CreatePartial(FAQ entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }

        public override ActionResult UpdatePartial(int id, FAQ entity)
        {
            entity.ModifiedDateTime = DateTime.Now;
            return base.UpdatePartial(id, entity);
        }
    }
}
