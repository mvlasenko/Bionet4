using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ParagraphsRepository: RepositoryBase<Paragraph, int>, IParagraphsRepository
    {
        public ParagraphsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}