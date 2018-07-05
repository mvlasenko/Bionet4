using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.Helpers;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //IProductsRepository repository = DependencyResolver.Current.GetService<IProductsRepository>();
            //foreach (Product product in repository.GetList())
            //{
            //    product.Description = product.Description.StripTags();
            //    product.ShortDescription = product.ShortDescription.StripTags();
            //    repository.Update(product);
            //}

            //IAlbumsRepository albumsRepository = DependencyResolver.Current.GetService<IAlbumsRepository>();
            //foreach (Album album in albumsRepository.GetList())
            //{
            //    album.Description = album.Description.StripTags();
            //    albumsRepository.Update(album);
            //}

            //IEventsRepository eventsRepository = DependencyResolver.Current.GetService<IEventsRepository>();
            //foreach (Event ev in eventsRepository.GetList())
            //{
            //    ev.ShortDescription = ev.ShortDescription.StripTags();
            //    eventsRepository.Update(ev);
            //}

            //IIngredientsRepository ingredientsRepository = DependencyResolver.Current.GetService<IIngredientsRepository>();
            //foreach (Ingredient item in ingredientsRepository.GetList())
            //{
            //    item.Name = item.Name.StripTags();
            //    item.Description = item.Description.StripTags();
            //    ingredientsRepository.Update(item);
            //}


            HomeViewModel model = new HomeViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Sliders = articlesRepository.GetListByType(ArticleType.Slider).Select(x => new SliderViewModel { ImageBig = "/Images/Image/" + x.ImageID.ToString(), ImageSmall = "/Images/Image/" + x.ImageID.ToString() + "?width=300&height=100", Text = x.Name, Paragraphs = x.Paragraphs.ToList() }).ToList();

            model.Thumbs = articlesRepository.GetList().Take(3).Select(x => new ThumbViewModel { Id = x.Id.ToString(), Name = x.Name, Description = x.Description, FaIcon = x.FaIcon }).ToList();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.ProductHighlights = productsRepository.GetList().Take(1).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ArticleViewModel model = new ArticleViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetByType(ArticleType.About);

            return View(model);
        }

        public ActionResult Quality()
        {
            ArticleViewModel model = new ArticleViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetByType(ArticleType.Quality);

            return View(model);
        }

        public ActionResult Opportunities()
        {
            ArticleViewModel model = new ArticleViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetByType(ArticleType.Opportunities);

            return View(model);
        }


    }
}