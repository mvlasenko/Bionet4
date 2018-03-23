using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class AlbumDetailsRepository: RepositoryBase<AlbumDetail, int>, IAlbumDetailsRepository
    {
        public AlbumDetailsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}