using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ProductsForOrderController : ApplicationController<ProductForOrder, int>
    {
        private IProductsForOrderRepository repository;

        public ProductsForOrderController(IProductsForOrderRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
