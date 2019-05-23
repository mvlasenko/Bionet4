using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class ArticlesController : Controller
    {
        public ActionResult Article(int id)
        {
            ArticleViewModel model = new ArticleViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetById(id);

            return View(model);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Business()
        {
            ArticlesViewModel model = new ArticlesViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Articles = articlesRepository.GetListByType(ArticleType.Business).OrderByDescending(x => x.PublishDate).ToList();

            return View(model);
        }

        public ActionResult Products()
        {
            ArticlesViewModel model = new ArticlesViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Articles = articlesRepository.GetListByType(ArticleType.Products).OrderByDescending(x => x.PublishDate).ToList();

            return View(model);
        }

        public ActionResult Post(int id)
        {
            ArticleViewModel model = new ArticleViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetById(id);

            return View("Post", model);
        }
    }
}