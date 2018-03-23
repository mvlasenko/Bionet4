using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class FAQController : ApiController<FAQ, int>
    {
        public FAQController() : base(DependencyResolver.Current.GetService<IFAQRepository>())
        {

        }
    }
}