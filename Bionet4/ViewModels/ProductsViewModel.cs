using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class ProductsViewModel
    {
        public List<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}