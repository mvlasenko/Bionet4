using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class AlbumDetailsController : ApiController<AlbumDetail, int>
    {
        public AlbumDetailsController() : base(DependencyResolver.Current.GetService<IAlbumDetailsRepository>())
        {

        }
    }
}