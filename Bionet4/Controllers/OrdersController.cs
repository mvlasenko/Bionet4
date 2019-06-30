using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Cart()
        {
            OrderViewModel model = new OrderViewModel();

            HttpCookie cookieCart = Request.Cookies["Cart"];
            if (cookieCart != null)
            {
                string[] ids = cookieCart.Value.Trim('_').Split('_').Distinct().ToArray();

                IProductsRepository repository = DependencyResolver.Current.GetService<IProductsRepository>();
                var products = repository.GetList().Where(x => ids.Contains(x.Id.ToString())).ToList();
                model.OrderItems = products.Select(x => new OrderItemViewModel { Count = 1, Product = x }).ToList();
                model.Total = model.OrderItems.Select(item => ((item.Product.PriceNew ?? item.Product.Price) * item.Count)).Sum();
            }

            return View("Cart", model);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Checkout(OrderViewModel model)
        {
            if (model.OrderItems.Any())
            {
                model.Total = model.OrderItems.Select(item => ((item.Product.PriceNew ?? item.Product.Price) * item.Count)).Sum();



            }




            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        if (model.OrderItems.Any())
            //        {
            //            //insert order
            //            IOrdersRepository ordersRepository = DependencyResolver.Current.GetService<IOrdersRepository>();
            //            IOrderItemsRepository orderItemsRepository = DependencyResolver.Current.GetService<IOrderItemsRepository>();

            //            //todo: add user
            //            Order order = ordersRepository.Insert(new Order { CreatedDateTime = DateTime.Now });

            //            foreach (OrderItemViewModel orderItem in model.OrderItems)
            //            {
            //                if (orderItem.Count > 0)
            //                {
            //                    orderItemsRepository.Insert(new OrderItem { OrderId = order.Id, ProductId = orderItem.Product.Id, ProductCount = orderItem.Count });
            //                }
            //            }

            //            return View("CreateSuccess", model);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //}

            return View("Checkout");
        }
    }
}