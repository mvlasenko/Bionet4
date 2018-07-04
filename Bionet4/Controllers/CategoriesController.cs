using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Category(int id)
        {
            ProductsViewModel model = new ProductsViewModel();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.Products = productsRepository.GetList().Where(x => x.CategoryId == id).ToList();

            ICategoriesRepository repository = DependencyResolver.Current.GetService<ICategoriesRepository>();
            model.Category = repository.GetById(id);

            return View("CategoryDetails", model);
        }
    }
}