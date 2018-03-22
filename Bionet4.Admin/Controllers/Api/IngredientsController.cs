using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class IngredientsController : ApiController<Ingredient, int>
    {
        public IngredientsController() : base(DependencyResolver.Current.GetService<IIngredientsRepository>())
        {

        }
    }
}