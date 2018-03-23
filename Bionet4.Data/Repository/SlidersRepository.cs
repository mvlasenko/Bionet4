using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class SlidersRepository: RepositoryBase<Slider, int>, ISlidersRepository
    {
        public SlidersRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}