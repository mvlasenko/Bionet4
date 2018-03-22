using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class LanguagesRepository: RepositoryBase<Language, int>, ILanguagesRepository
    {
        public LanguagesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}