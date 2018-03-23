using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class VideosController : ApplicationController<Video, int>
    {
        private IVideosRepository repository;

        public VideosController(IVideosRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
