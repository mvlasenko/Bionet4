using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int? id, int? category = null)
        {
            ProductsViewModel model = new ProductsViewModel();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            List<Product> products = productsRepository.GetList().ToList();

            if (category != null)
            {
                products = products.Where(x => x.CategoryId == category).ToList();
            }

            if (id != null && id > 1)
            {
                model.Products = products.Skip((int)id * 15 - 15).Take(15).ToList();
            }
            else
            {
                model.Products = products.Take(15).ToList();
            }

            //todo: aggregete count
            model.ProductsBest = products.Where(x => x.Bestseller == true).ToList();

            model.IndexMax = products.Count / 15 + 1;
            model.IndexCurrent = id != null && id > 1 ? id.Value : 1;

            ICategoriesRepository categoriesRepository = DependencyResolver.Current.GetService<ICategoriesRepository>();
            List<Category> allCategories = categoriesRepository.GetList().ToList();
            List<int?> nonEmptyCategories = ((ProductsRepository)productsRepository).GetCategoriesNonEmpty();

            model.Categories = allCategories.Where(c => nonEmptyCategories.Contains(c.Id)).ToList();

            return View(model);
        }

        public ActionResult Product(int id)
        {
            ProductDetailsViewModel model = new ProductDetailsViewModel();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.Product = productsRepository.GetById(id);

            return View("Details", model);
        }

        public ActionResult AddCart(int id)
        {
            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            Product product = productsRepository.GetById(id);

            return PartialView("_AddCartPartial", product);
        }

    }
}