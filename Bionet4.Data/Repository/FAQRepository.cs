using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class FAQRepository: RepositoryBase<FAQ, int>, IFAQRepository
    {
        public FAQRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}