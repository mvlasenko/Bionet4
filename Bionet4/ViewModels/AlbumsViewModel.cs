using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class AlbumsViewModel
    {
        public Article Intro { get; set; }
        public List<Album> Albums { get; set; }
    }
}