using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class AlbumsRepository: RepositoryBase<Album, int>, IAlbumsRepository
    {
        public AlbumsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}