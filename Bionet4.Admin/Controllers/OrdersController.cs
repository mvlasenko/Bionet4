using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class OrdersController : ApplicationController<Order, int>
    {
        private IOrdersRepository repository;

        public OrdersController(IOrdersRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
