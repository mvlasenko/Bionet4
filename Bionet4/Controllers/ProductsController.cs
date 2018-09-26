﻿using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index(int? id)
        {
            ProductsViewModel model = new ProductsViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.ProductsIntro);

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.Products = productsRepository.GetList().Take(15).ToList();
            model.ProductsBest = model.Products.Take(2).ToList();

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