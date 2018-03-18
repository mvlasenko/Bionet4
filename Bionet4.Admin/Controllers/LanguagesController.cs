using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class LanguagesController : ApplicationController<Language, int>
    {
        private ILanguagesRepository repository;

        public LanguagesController(ILanguagesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

