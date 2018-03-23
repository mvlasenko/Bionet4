using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class AlbumsController : ApiController<Album, int>
    {
        public AlbumsController() : base(DependencyResolver.Current.GetService<IAlbumsRepository>())
        {

        }
    }
}