using Bionet4.Data.Models;
using System.Collections.Generic;

namespace Bionet4.ViewModels
{
    public class HomeViewModel
    {
        public List<SliderViewModel> Sliders { get; set; }
        public List<Article> ActicleThumbs { get; set; }
        public List<Product> ProductHighlights { get; set; }
    }
}