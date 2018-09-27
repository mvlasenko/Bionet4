using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class ProductsViewModel
    {
        public Article Intro { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> ProductsBest { get; set; }
        public List<Category> Categories { get; set; }
        public int IndexMax { get; set; }
        public int IndexCurrent { get; set; }
    }
}