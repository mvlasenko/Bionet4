using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            ProductsViewModel model = new ProductsViewModel();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.Products = productsRepository.GetList().ToList();

            return View(model);
        }

        public ActionResult Product(int id)
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.Product = productsRepository.GetById(id);

            return View("Details", model);
        }

    }
}