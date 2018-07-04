using Bionet4.Data.Contracts;
using Bionet4.Data.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Bionet4.Data.Repository
{
    public class ArticleRepository: RepositoryBase<Article, int>, IArticleRepository
    {
        public ArticleRepository(IDbContextFactory factory) : base(factory)
        {
        }

        public override Article GetById(int id)
        {
            return this.DbSet.Where(x => x.Id == id).Include(x => x.Paragraphs).FirstOrDefault();
        }

        public Article GetByType(ArticleType articleType)
        {
            return this.DbSet.Where(x => x.ArticleType == articleType).Include(x => x.Paragraphs).FirstOrDefault();
        }

        public List<Article> GetListByType(ArticleType articleType)
        {
            return this.DbSet.Where(x => x.ArticleType == articleType).Include(x => x.Paragraphs).ToList();
        }

    }
}