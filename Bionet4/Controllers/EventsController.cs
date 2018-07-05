using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            EventsViewModel model = new EventsViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.EventsIntro);

            IEventsRepository eventsRepository = DependencyResolver.Current.GetService<IEventsRepository>();
            model.Events = eventsRepository.GetList().OrderByDescending(x => x.EventDateTime).ToList();

            return View(model);
        }
    }
}