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

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.ProductsIntro);

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            List<Product> products = productsRepository.GetList().ToList();

            if (category != null)
            {
                products = products.Where(x => x.CategoryId == category).ToList();
            }

            if (id != null && id > 1)
            {
                model.Products = products.Skip((int)id * 15).Take(15).ToList();
            }
            else
            {
                model.Products = products.Take(15).ToList();
            }

            //todo: aggregete count
            model.ProductsBest = products.Where(x => x.Bestseller == true).ToList();

            model.IndexMax = products.Count;
            model.IndexCurrent = id != null && id > 1 ? id.Value : 1;

            ICategoriesRepository categoriesRepository = DependencyResolver.Current.GetService<ICategoriesRepository>();
            model.Categories = categoriesRepository.GetList().ToList();

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