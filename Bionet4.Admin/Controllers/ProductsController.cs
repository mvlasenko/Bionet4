using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ProductsController : ApplicationController<Product, int>
    {
        private IProductsRepository repository;

        public ProductsController(IProductsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}

