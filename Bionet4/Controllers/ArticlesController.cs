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

        public ActionResult All()
        {
            ArticlesViewModel model = new ArticlesViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.ArticlesAllIntro);
            model.Articles = articlesRepository.GetList().OrderByDescending(x => x.PublishDate).ToList();
            if (model.Intro == null)
                model.Intro = model.Articles.FirstOrDefault();

            return View(model);
        }

        public ActionResult Business()
        {
            ArticlesViewModel model = new ArticlesViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.ArticlesBusinessIntro);
            model.Articles = articlesRepository.GetListByType(ArticleType.Business).OrderByDescending(x => x.PublishDate).ToList();
            if (model.Intro == null)
                model.Intro = model.Articles.FirstOrDefault();

            return View(model);
        }

        public ActionResult Products()
        {
            ArticlesViewModel model = new ArticlesViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.ArticlesProductsIntro);
            model.Articles = articlesRepository.GetListByType(ArticleType.Products).OrderByDescending(x => x.PublishDate).ToList();
            if (model.Intro == null)
                model.Intro = model.Articles.FirstOrDefault();

            return View(model);
        }
    }
}