using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class SliderViewModel
    {
        public string ImageSmall { get; set; }
        public string ImageBig { get; set; }
        public string Text { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
    }
}