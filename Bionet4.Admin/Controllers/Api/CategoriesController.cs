using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class CategoriesController : ApiController<Category, int>
    {
        public CategoriesController() : base(DependencyResolver.Current.GetService<ICategoriesRepository>())
        {

        }
    }
}