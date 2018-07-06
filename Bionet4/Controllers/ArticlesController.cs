using System.Web.Mvc;
using Bionet4.Data.Contracts;
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
    }
}