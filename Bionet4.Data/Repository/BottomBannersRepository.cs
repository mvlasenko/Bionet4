using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class BottomBannersRepository: RepositoryBase<BottomBanner, int>, IBottomBannersRepository
    {
        public BottomBannersRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}