using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult Index()
        {
            AlbumsViewModel model = new AlbumsViewModel();

            IAlbumsRepository albumsRepository = DependencyResolver.Current.GetService<IAlbumsRepository>();
            model.Albums = albumsRepository.GetList().ToList();

            IAlbumDetailsRepository detailsRepository = DependencyResolver.Current.GetService<IAlbumDetailsRepository>();
            model.AlbumDetails = detailsRepository.GetList().ToList();

            return View(model);
        }
    }
}