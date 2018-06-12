using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System;

namespace Bionet4.Data.Repository
{
    public class VideosRepository: RepositoryBase<Video, Guid>, IVideosRepository
    {
        public VideosRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}