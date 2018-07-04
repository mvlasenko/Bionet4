using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Helpers;

namespace Bionet4.Admin.Controllers
{
    public class ParagraphsController : ApplicationController<Paragraph, int>
    {
        private IParagraphsRepository repository;

        public ParagraphsController(IParagraphsRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult CreateParagraph(int ArticleId)
        {
            Paragraph entity = new Paragraph();
            entity.ArticleId = ArticleId;

            return PartialView("_CreatePartial", entity);
        }

        [HttpPost, ValidateInput(false)]
        public override ActionResult CreatePartial([Bind(Prefix = "paragraph")] Paragraph entity)
        {
            return base.CreatePartial(entity);
        }

        [HttpPost, ValidateInput(false)]
        public override ActionResult UpdatePartial(int id, [Bind(Prefix = "paragraph")] Paragraph entity)
        {
            return base.UpdatePartial(id, entity);
        }

        public JsonResult GetParagraphs(int ArticleId)
        {
            var list = repository.GetList().Where(x => x.ArticleId == ArticleId);//.Select(x => new Paragraph { Id = x.Id, Name = x.Name, Description = x.Description.Cut(30), ImageID = x.ImageID, FaIcon = x.FaIcon, ArticleId = x.ArticleId, SeqID =x.SeqID });
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
