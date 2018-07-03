using System.Collections.Generic;
using Bionet4.Data.Models;

namespace Bionet4.ViewModels
{
    public class AlbumsViewModel
    {
        public List<Album> Albums { get; set; }
        public List<AlbumDetail> AlbumDetails { get; set; }
    }
}