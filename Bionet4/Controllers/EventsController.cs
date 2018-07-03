using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            EventsViewModel model = new EventsViewModel();

            IEventsRepository eventsRepository = DependencyResolver.Current.GetService<IEventsRepository>();
            model.Events = eventsRepository.GetList().ToList();

            return View(model);
        }
    }
}