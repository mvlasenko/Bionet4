using System;
using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class AlbumDetailsController : ApplicationController<AlbumDetail, int>
    {
        private IAlbumDetailsRepository repository;

        public AlbumDetailsController(IAlbumDetailsRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet, ValidateInput(false)]
        public ActionResult CreateAlbumDetail(int AlbumId)
        {
            AlbumDetail entity = new AlbumDetail();
            entity.AlbumId = AlbumId;

            return PartialView("_CreatePartial", entity);
        }

        [HttpPost, ValidateInput(false)]
        public override ActionResult CreatePartial([Bind(Prefix = "ad")] AlbumDetail entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }

        [HttpPost, ValidateInput(false)]
        public override ActionResult UpdatePartial(int id, [Bind(Prefix = "ad")] AlbumDetail entity)
        {
            return base.UpdatePartial(id, entity);
        }

        public JsonResult GetAlbumDetails(int AlbumId)
        {
            var list = repository.GetList().Where(x => x.AlbumId == AlbumId);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}
