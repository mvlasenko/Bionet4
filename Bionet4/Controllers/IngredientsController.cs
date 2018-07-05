using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class IngredientsController : Controller
    {
        public ActionResult Index()
        {
            IngredientsViewModel model = new IngredientsViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.IngredientsIntro);

            IIngredientsRepository ingredientsRepository = DependencyResolver.Current.GetService<IIngredientsRepository>();
            model.Ingredients = ingredientsRepository.GetList().ToList();

            return View(model);
        }
    }
}