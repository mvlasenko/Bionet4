using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();

            model.Sliders = articlesRepository.GetList().Select(x => new SliderViewModel { ImageBig = "/Images/Image/" + x.ImageID.ToString(), ImageSmall = "/Images/Image/" + x.ImageID.ToString() + "?width=100", Text = x.Name }).ToList();

            model.ActicleThumbs = articlesRepository.GetList().Take(3).Select(x=> new ArticleViewModel { Id = x.Id.ToString(), Name = x.Name, Description = x.Description, FaIcon = x.FaIcon }).ToList();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.ProductHighlights = productsRepository.GetList().Take(1).ToList();

            return View(model);
        }
    }
}