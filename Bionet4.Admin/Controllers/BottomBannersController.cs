using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class BottomBannersController : ApplicationController<BottomBanner, int>
    {
        private IBottomBannersRepository repository;

        public BottomBannersController(IBottomBannersRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
