using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class AlbumsRepository: RepositoryBase<Album, int>, IAlbumsRepository
    {
        public AlbumsRepository(IDbContextFactory factory) : base(factory)
        {
        }

        public List<Album> GetListWithIncludes()
        {
            return this.DbSet.Include(x => x.AlbumDetails).ToList();
        }

        public Album GetByIdWithIncludes(int id)
        {
            return this.DbSet.Include(x => x.AlbumDetails).FirstOrDefault(x=> x.Id == id);
        }

    }
}