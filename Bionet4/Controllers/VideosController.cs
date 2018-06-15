using System;
using System.IO;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Helpers;

namespace Bionet4.Controllers
{
    public class VideosController : Controller
    {
        public ActionResult Video(string id)
        {
            IVideosRepository repository = DependencyResolver.Current.GetService<IVideosRepository>();

            var video = repository.GetById(new Guid(id));

            return File(new MemoryStream(video.Binary), ImageHelper.GetContentType(Path.GetExtension(video.FileName)), video.FileName);
        }
    }
}