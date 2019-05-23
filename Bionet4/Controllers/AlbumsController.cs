using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class AlbumsController : Controller
    {
        public ActionResult Index()
        {
            AlbumsViewModel model = new AlbumsViewModel();

            AlbumsRepository albumsRepository = (AlbumsRepository)DependencyResolver.Current.GetService<IAlbumsRepository>();
            model.Albums = albumsRepository.GetListWithIncludes();
            foreach (Album album in model.Albums)
            {
                if (album.ImageID == null && album.AlbumDetails.Any(x => x.ImageID != null))
                    album.ImageID = album.AlbumDetails.First(x => x.ImageID != null).ImageID;
            }

            return View(model);
        }

        public ActionResult Album(int id)
        {
            AlbumsRepository albumsRepository = (AlbumsRepository)DependencyResolver.Current.GetService<IAlbumsRepository>();
            Album model = albumsRepository.GetByIdWithIncludes(id);

            return View("AlbumDetails", model);
        }

    }
}