using System;
using System.IO;
using System.Linq;
using System.Web;
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
            if (ModelState.IsValid)
            {
                try
                {
                    if (entity.Id == Guid.Empty)
                    {
                        entity.CreatedDateTime = DateTime.Now;
                        repository.Insert(entity);
                    }
                    else
                    {
                        Video original = repository.GetById(entity.Id);
                        original.Name = entity.Name;

                        repository.Update(original);
                    }

                    var list = repository.GetList();
                    return Json(new { totalCount = list.Count });
                }
                catch (Exception ex)
                {
                    //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                    throw;
                }
            }

            return Json(new { success = false });
        }

        public override ActionResult UpdatePartial(Guid id, Video entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Video original = repository.GetById(id);
                    original.Name = entity.Name;

                    repository.Update(original);

                    return Json(new { success = true });
                }
                catch (Exception ex)
                {
                    //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                    throw;
                }
            }

            return Json(new { success = false });
        }

        [Route("Video/{id}")]
        public ActionResult Video(string id)
        {
            var entity = repository.GetById(new Guid(id));
            return File(new MemoryStream(entity.Binary), ImageHelper.GetContentType(Path.GetExtension(entity.FileName)), entity.FileName);
        }

        [HttpPost]
        public virtual ActionResult FileUploadInsert(HttpPostedFileBase file)
        {
            var memStream = new MemoryStream();
            file.InputStream.CopyTo(memStream);

            byte[] fileData = memStream.ToArray();

            Video newVideo = this.repository.Insert(new Video { Binary = fileData, Name = file.FileName, FileName = file.FileName, CreatedDateTime = DateTime.Now });

            return Json(new
            {
                files = new[]
                {
                    new {
                        id = newVideo.Id,
                        url = "/admin/Videos/Video/" + newVideo.Id,
                        type = ImageHelper.GetContentType(Path.GetExtension(newVideo.FileName)),
                        thumbnailUrl = "/admin/Content/images/video.png",
                        size = newVideo.Binary.Length,
                        name = newVideo.FileName
                    }
                }
            });
        }

        [HttpPost]
        public virtual ActionResult FileUploadUpdate(string Id, string Name, HttpPostedFileBase file)
        {
            var memStream = new MemoryStream();
            file.InputStream.CopyTo(memStream);

            byte[] fileData = memStream.ToArray();

            //get existing
            Video video = this.repository.GetById(new Guid(Id));
            video.Binary = fileData;
            video.Name = Name;
            video.FileName = file.FileName;

            //update
            this.repository.Update(video);

            return Json(new
            {
                files = new[]
                {
                    new {
                        id = video.Id,
                        url = "/admin/Videos/Video/" + video.Id,
                        type = ImageHelper.GetContentType(Path.GetExtension(video.FileName)),
                        thumbnailUrl = "/admin/Content/images/video.png",
                        size = video.Binary.Length,
                        name = video.FileName
                    }
                }
            });
        }
    }
}
