using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class OrderViewModel
    {
        public Article Intro { get; set; }
        public List<ProductForOrder> ProductsForOrder { get; set; }
    }
}