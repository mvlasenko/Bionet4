using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class ProductsController : ApiController<Product, int>
    {
        public ProductsController() : base(DependencyResolver.Current.GetService<IProductsRepository>())
        {

        }
    }
}