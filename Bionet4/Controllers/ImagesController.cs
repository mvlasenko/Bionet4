using System;
using System.IO;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Helpers;

namespace Bionet4.Controllers
{
    public class ImagesController : Controller
    {
        public ActionResult Image(string id, int? width, int? height, bool crop = true, bool center = true)
        {
            byte[] binary;
            string name;

            if (id == null)
            {
                name = "dummy.jpg";
                binary = System.IO.File.ReadAllBytes(this.Server.MapPath("~/Content/images/dummy.jpg"));
            }
            else
            {
                IImagesRepository repository = DependencyResolver.Current.GetService<IImagesRepository>();
                var imageEntity = repository.GetById(new Guid(id));

                name = imageEntity.Name;

                if (width == null && height == null)
                {
                    binary = imageEntity.Binary;
                }
                else
                {
                    string key = "File_" + id + "_width_" + width + "_height_" + height + "_crop_" + crop + "_center_" + center;

                    binary = this.HttpContext.Cache[key] as byte[];
                    if (binary == null)
                    {
                        binary = crop && width.HasValue && height.HasValue ?
                            ImageHelper.GetImageCroped(imageEntity.Binary, width.Value, height.Value, center) :
                            ImageHelper.GetImageResized(imageEntity.Binary, width.HasValue ? width.Value : 0, height.HasValue ? height.Value : 0);
                        this.HttpContext.Cache.Insert(key, binary);
                    }
                }
            }

            return File(new MemoryStream(binary), ImageHelper.GetContentType(Path.GetExtension(name)), name);
        }
    }
}