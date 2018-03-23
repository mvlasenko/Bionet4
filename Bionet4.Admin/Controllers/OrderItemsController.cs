using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class OrderItemsController : ApplicationController<OrderItem, int>
    {
        private IOrderItemsRepository repository;

        public OrderItemsController(IOrderItemsRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
