using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class MailTemplatesController : ApplicationController<MailTemplate, int>
    {
        private IMailTemplatesRepository repository;

        public MailTemplatesController(IMailTemplatesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
