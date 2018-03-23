using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class VideosRepository: RepositoryBase<Video, int>, IVideosRepository
    {
        public VideosRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}