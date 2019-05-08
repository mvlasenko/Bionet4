using System;
using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System.Reflection;
using Bionet4.Admin.Attributes;

namespace Bionet4.Admin.Controllers
{
    public class ArticleController : ApplicationController<Article, int>
    {
        private IArticleRepository repository;

        public ArticleController(IArticleRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public override ActionResult Create()
        {
            Article entity = new Article();
            entity.PublishDate = DateTime.Now;

            ViewBag.RtfFields = typeof(Article).GetProperties().Where(prop => prop.GetCustomAttributes().Any(x => x is RtfAttribute)).Select(prop => new ViewModels.FieldInfo { Name = prop.Name }).ToList();

            return View("New", entity);
        }

        public override ActionResult Create(Article entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.Create(entity);
        }

        public override ActionResult CreatePartial()
        {
            Article entity = new Article();
            entity.PublishDate = DateTime.Now;

            return PartialView("_CreatePartial", entity);
        }

        public override ActionResult CreatePartial(Article entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            return base.CreatePartial(entity);
        }

        public override Func<Article, bool> GetWhere(string f)
        {
            //Dictionary<string, string> filters = f.Split(';').Select(x => new KeyValuePair<string, string>(x.Split('=')[0], x.Split('=')[1])).ToDictionary(x => x.Key, x => x.Value);
            return new Func<Article, bool>(x => true);
        }

    }
}
