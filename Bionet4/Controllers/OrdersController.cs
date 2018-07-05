using System;
using System.Linq;
using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using Bionet4.Data.Repository;
using Bionet4.ViewModels;

namespace Bionet4.Controllers
{
    public class OrdersController : Controller
    {
        [HttpGet, ValidateInput(false)]
        public virtual ActionResult Create()
        {
            OrderViewModel model = new OrderViewModel();

            ArticleRepository articlesRepository = (ArticleRepository)DependencyResolver.Current.GetService<IArticleRepository>();
            model.Intro = articlesRepository.GetByType(ArticleType.OrderIntro);

            IProductsForOrderRepository repository = DependencyResolver.Current.GetService<IProductsForOrderRepository>();
            model.ProductsForOrder = repository.GetList().ToList();

            return View("Create", model);
        }

        [HttpPost, ValidateInput(false)]
        public virtual ActionResult Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ProductsForOrder.Any(x => x.Point != null && x.Point > 0))
                    {
                        //insert order
                        IOrdersRepository ordersRepository = DependencyResolver.Current.GetService<IOrdersRepository>();
                        IOrderItemsRepository orderItemsRepository = DependencyResolver.Current.GetService<IOrderItemsRepository>();

                        //todo: add user
                        Order order = ordersRepository.Insert(new Order { CreatedDateTime = DateTime.Now });

                        foreach (ProductForOrder product in model.ProductsForOrder)
                        {
                            if (product.Point != null && product.Point > 0)
                            {
                                orderItemsRepository.Insert(new OrderItem { OrderId = order.Id, ProductForOrderId = product.Id, ProductCount = (int)product.Point });
                            }
                        }

                        return View("CreateSuccess", model);
                    }
                }
                catch (Exception ex)
                {
                    //SiteLogger.Error("Exception occurred in {2}: {0}\r\n{1}", LoggingCategory.General, ex.Message, ex.StackTrace, this.GetType().Name);
                    throw;
                }
            }

            return View("Create", model);
        }
    }
}