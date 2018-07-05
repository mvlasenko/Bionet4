using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class FaqViewModel
    {
        public Article Intro { get; set; }
        public List<FAQ> Faq { get; set; }
    }
}