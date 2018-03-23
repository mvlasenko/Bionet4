using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class AlbumsController : ApplicationController<Album, int>
    {
        private IAlbumsRepository repository;

        public AlbumsController(IAlbumsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
