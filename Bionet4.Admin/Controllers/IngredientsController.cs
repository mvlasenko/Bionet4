using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class IngredientsController : ApplicationController<Ingredient, int>
    {
        private IIngredientsRepository repository;

        public IngredientsController(IIngredientsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
