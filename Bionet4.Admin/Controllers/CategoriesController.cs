using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class CategoriesController : ApplicationController<Category, int>
    {
        private ICategoriesRepository repository;

        public CategoriesController(ICategoriesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

