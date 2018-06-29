using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bionet4.Data.Contracts;

namespace Bionet4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IAgentsRepository repository = DependencyResolver.Current.GetService<IAgentsRepository>();
            var list = repository.GetList().ToList();


            return View();
        }

    }
}