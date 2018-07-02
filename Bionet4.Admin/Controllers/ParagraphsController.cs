using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ParagraphsController : ApplicationController<Paragraph, int>
    {
        private IParagraphsRepository repository;

        public ParagraphsController(IParagraphsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
