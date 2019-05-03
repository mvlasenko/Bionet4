using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class ArticlesViewModel
    {
        public Article Intro { get; set; }
        public List<Article> Articles { get; set; }
    }
}