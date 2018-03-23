using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class ProductsForOrderController : ApiController<ProductForOrder, int>
    {
        public ProductsForOrderController() : base(DependencyResolver.Current.GetService<IProductsForOrderRepository>())
        {

        }
    }
}