using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System;

namespace Bionet4.Data.Repository
{
    public class ImagesRepository: RepositoryBase<Image, Guid>, IImagesRepository
    {
        public ImagesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}