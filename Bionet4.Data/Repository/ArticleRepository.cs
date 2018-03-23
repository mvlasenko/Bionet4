using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class ArticleRepository: RepositoryBase<Article, int>, IArticleRepository
    {
        public ArticleRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}