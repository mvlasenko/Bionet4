using System;
using System.IO;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Helpers;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class VideosController : ApplicationController<Video, Guid>
    {
        private IVideosRepository repository;

        public VideosController(IVideosRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ActionResult CreatePartial(Video entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }

        [Route("Video/{id}")]
        public ActionResult Video(string id)
        {
            var entity = repository.GetById(new Guid(id));
            return File(new MemoryStream(entity.Binary), ImageHelper.GetContentType(Path.GetExtension(entity.Name)), entity.Name);
        }

    }
}
