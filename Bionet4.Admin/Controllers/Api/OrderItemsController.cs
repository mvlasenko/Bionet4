using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class OrderItemsController : ApiController<OrderItem, int>
    {
        public OrderItemsController() : base(DependencyResolver.Current.GetService<IOrderItemsRepository>())
        {

        }
    }
}