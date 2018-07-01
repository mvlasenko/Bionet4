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

            ISlidersRepository slidersRepository = DependencyResolver.Current.GetService<ISlidersRepository>();
            model.Sliders = slidersRepository.GetList().Select(x => new SliderViewModel { ImageBig = "/Images/Image/" + x.ImageID.ToString(), ImageSmall = "/Images/Image/" + x.ImageID.ToString() + "?width=100", Text = x.Name }).ToList();

            IArticleRepository articlesRepository = DependencyResolver.Current.GetService<IArticleRepository>();
            model.ActicleThumbs = articlesRepository.GetList().Take(3).ToList();

            IProductsRepository productsRepository = DependencyResolver.Current.GetService<IProductsRepository>();
            model.ProductHighlights = productsRepository.GetList().Take(1).ToList();

            return View(model);
        }
    }
}