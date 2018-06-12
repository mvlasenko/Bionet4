using System;
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

        public override ActionResult CreatePartial(AlbumDetail entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }
    }
}
