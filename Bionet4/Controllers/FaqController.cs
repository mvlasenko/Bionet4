using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class FaqController : Controller
    {
        public ActionResult Index()
        {
            FaqViewModel model = new FaqViewModel();

            IFAQRepository faqRepository = DependencyResolver.Current.GetService<IFAQRepository>();
            model.Faq = faqRepository.GetList().ToList();

            return View(model);
        }
    }
}