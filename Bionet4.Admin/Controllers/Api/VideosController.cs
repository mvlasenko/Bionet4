using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class VideosController : ApiController<Video, int>
    {
        public VideosController() : base(DependencyResolver.Current.GetService<IVideosRepository>())
        {

        }
    }
}