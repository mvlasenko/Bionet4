using System.Data.Entity;

namespace Bionet4.Data.Contracts
{
    public interface IDbContextFactory
    {
        DbContext GetDbContext();
    }
}
