using Bionet4.Data.Models;
using System;

namespace Bionet4.Data.Contracts
{
    public interface IImagesRepository : IRepository<Image, Guid>
    {
    }
}