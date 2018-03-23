using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class FAQController : ApplicationController<FAQ, int>
    {
        private IFAQRepository repository;

        public FAQController(IFAQRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
