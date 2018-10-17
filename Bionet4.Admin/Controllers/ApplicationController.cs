using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Bionet4.Admin.Attributes;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models.Filters;

namespace Bionet4.Admin.Controllers
{
    [Authorize]
    public abstract class ApplicationController<T, TKey> : Controller where T : class, IEntity<TKey>, new()
    {
        private readonly IRepository<T, TKey> repository;

        protected ApplicationController(IRepository<T, TKey> repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public virtual ActionResult Index(IFilter<T, TKey> filter)
        {
            IPagedCollection model = this.LoadCollection(filter);

            ViewBag.ListFields = typeof(T).GetProperties().Where(prop => prop.GetCustomAttributes().Any(x => x is IncludeListAttribute)).Select(prop => new ViewModels.FieldInfo { Name = prop.Name, Type = prop.PropertyType, TypeName = GetTypeName(prop), UIHint = prop.GetCustomAttributes().Any(x => x is UIHintAttribute) ? ((UIHintAttribute)prop.GetCustomAttributes().First(x => x is UIHintAttribute)).UIHint : "" }).ToList();
            ViewBag.ListFieldHeaders = typeof(T).GetProperties().Where(prop => prop.GetCustomAttributes().Any(x => x is IncludeListAttribute)).Select(prop => ((IncludeListAttribute)prop.GetCustomAttributes().First(x => x is IncludeListAttribute)).IncludeListTitle ?? prop.Name).ToList();

            return View("Index", model);
        }

        public string GetTypeName(PropertyInfo prop)
        {
            var propertyType = prop.PropertyType;

            if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                propertyType = propertyType.GetGenericArguments()[0];
            }

            return propertyType.Name;
        }

        [HttpGet]
        public virtual ActionResult Show(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404("Show", model);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Create()
        {
            T model = new T();
            return View("New", model);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Create(T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity = repository.Insert(entity);
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                    throw;
                }
            }

            return View("New", entity);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult CreatePartial()
        {
            T entity = new T();
            return PartialView("_CreatePartial", entity);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult CreatePartial(T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Insert(entity);

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

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Update(TKey id)
        {
            dynamic model = this.LoadModel(id);
            return ObjectOr404("Edit", model);
        }

        [HttpPut, ValidateInput(false)]
        public virtual ActionResult Update(TKey id, T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    entity = repository.Update(entity);
                    return RedirectToDefaultUrl(entity);
                }
                catch (Exception ex)
                {
                    //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                    throw;
                }
            }

            return View("Edit", entity);
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult UpdatePartial(TKey id)
        {
            dynamic entity = this.LoadModel(id);
            return PartialView("_EditPartial", entity);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult UpdatePartial(TKey id, T entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    repository.Update(entity);
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

        public virtual ActionResult Destroy(TKey id)
        {
            try
            {
                T entity = repository.GetById(id);
                repository.Delete(entity);
            }
            catch (Exception ex)
            {
                //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                throw;
            }

            return RedirectToCollectionUrl();
        }

        [HttpGet, ValidateInput(false)]
        public virtual ActionResult DestroyPartial(TKey id)
        {
            try
            {
                T entity = repository.GetById(id);
                repository.Delete(entity);

                var list = repository.GetList();
                return Json(new { totalCount = list.Count }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                throw;
            }
        }

        [HttpGet]
        public virtual JsonResult GetList()
        {
            var list = repository.GetList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public virtual JsonResult GetPagedList(int? id)
        {
            IFilter<T, TKey> filter = new Filter<T, TKey>();
            filter.PageIndex = id == null ? 1 : id.Value;

            var list = repository.GetPagedList(filter);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual ActionResult ImageUpload(HttpPostedFileBase file)
        {
            try
            {
                IImagesRepository imagesRepository = DependencyResolver.Current.GetService<IImagesRepository>();

                var memStream = new MemoryStream();
                file.InputStream.CopyTo(memStream);

                byte[] fileData = memStream.ToArray();

                //get existing
                Data.Models.Image newImage = imagesRepository.GetList().FirstOrDefault(x => x.Name == file.FileName && x.Binary.Length == fileData.Length);
                //get from database
                if (newImage == null)
                    newImage = imagesRepository.Insert(new Data.Models.Image { Binary = fileData, Name = file.FileName, CreatedDateTime = DateTime.Now });

                return Json(new
                {
                    success = true,
                    response = "Image uploaded.",
                    id = newImage.Id.ToString(),
                    fileName = file.FileName
                });
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    success = false,
                    response = exception.Message
                });
            }
        }

        #region helpers

        protected virtual IPagedCollection LoadCollection(IFilter<T, TKey> filter)
        {
            return repository.GetPaged(filter);
        }

        protected virtual dynamic LoadModel(TKey id)
        {
            return repository.GetById(id);
        }

        protected virtual RedirectToRouteResult RedirectToCollectionUrl()
        {
            return RedirectToAction("Index");
        }

        protected virtual RedirectToRouteResult RedirectToResourceUrl(T resource)
        {
            return RedirectToAction("Show", new { @id = resource.Id });
        }

        protected virtual RedirectToRouteResult RedirectToDefaultUrl(T resource)
        {
            return RedirectToCollectionUrl();
        }

        protected virtual ActionResult ObjectOr404(object entity)
        {
            return ObjectOr404(null, entity);
        }

        protected virtual ActionResult ObjectOr404(string viewName, object entity)
        {
            if (entity == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                return View(viewName, entity);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && repository != null)
            {
                repository.Dispose();
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}