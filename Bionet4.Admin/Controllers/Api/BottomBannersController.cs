using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class BottomBannersController : ApiController<BottomBanner, int>
    {
        public BottomBannersController() : base(DependencyResolver.Current.GetService<IBottomBannersRepository>())
        {

        }
    }
}