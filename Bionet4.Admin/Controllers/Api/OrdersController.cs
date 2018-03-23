using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class OrdersController : ApiController<Order, int>
    {
        public OrdersController() : base(DependencyResolver.Current.GetService<IOrdersRepository>())
        {

        }
    }
}