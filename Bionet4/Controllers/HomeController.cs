using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();

            model.Sliders = articlesRepository.GetList().Where(x => x.ArticleType == ArticleType.Slider).Select(x => new SliderViewModel { ImageBig = "/Images/Image/" + x.ImageID.ToString(), ImageSmall = "/Images/Image/" + x.ImageID.ToString() + "?width=100", Text = x.Name }).ToList();

            model.Thumbs = articlesRepository.GetList().Take(3).Select(x=> new ThumbViewModel { Id = x.Id.ToString(), Name = x.Name, Description = x.Description, FaIcon = x.FaIcon }).ToList();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.ProductHighlights = productsRepository.GetList().Take(1).ToList();

            return View(model);
        }

        public ActionResult About()
        {
            ArticleViewModel model = new ArticleViewModel();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetList().Where(x => x.ArticleType == ArticleType.About).FirstOrDefault();

            return View(model);
        }

        public ActionResult Quality()
        {
            ArticleViewModel model = new ArticleViewModel();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetList().Where(x => x.ArticleType == ArticleType.Quality).FirstOrDefault();

            return View(model);
        }

        public ActionResult Opportunities()
        {
            ArticleViewModel model = new ArticleViewModel();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();

            model.Article = articlesRepository.GetList().Where(x => x.ArticleType == ArticleType.Opportunities).FirstOrDefault();

            return View(model);
        }


    }
}