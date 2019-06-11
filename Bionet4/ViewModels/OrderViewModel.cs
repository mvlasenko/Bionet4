using System.Collections.Generic;

namespace Bionet4.ViewModels
{
    public class OrderViewModel
    {
        public decimal? Total { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
    }
}