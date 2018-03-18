using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class CountriesRepository: RepositoryBase<Country, int>, ICountriesRepository
    {
        public CountriesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}