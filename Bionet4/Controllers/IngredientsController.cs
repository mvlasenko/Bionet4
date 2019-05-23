using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class IngredientsController : Controller
    {
        public ActionResult Index()
        {
            IngredientsViewModel model = new IngredientsViewModel();

            IIngredientsRepository ingredientsRepository = DependencyResolver.Current.GetService<IIngredientsRepository>();
            model.Ingredients = ingredientsRepository.GetList().ToList();

            return View(model);
        }
    }
}