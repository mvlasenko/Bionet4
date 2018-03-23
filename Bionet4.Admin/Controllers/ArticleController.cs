using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class ArticleController : ApplicationController<Article, int>
    {
        private IArticleRepository repository;

        public ArticleController(IArticleRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
