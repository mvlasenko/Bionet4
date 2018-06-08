using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System;

namespace Bionet4.Admin.Controllers
{
    public class ImagesController : ApplicationController<Image, Guid>
    {
        private IImagesRepository repository;

        public ImagesController(IImagesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
