using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System.Data.Entity;

namespace Bionet4.Data.Repository
{
    public class DbContextFactory : IDbContextFactory
    {
        public DbContext GetDbContext()
        {
            return new Bionet4Context();
        }
    }
}
