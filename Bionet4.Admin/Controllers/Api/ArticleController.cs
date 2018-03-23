using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class ArticleController : ApiController<Article, int>
    {
        public ArticleController() : base(DependencyResolver.Current.GetService<IArticleRepository>())
        {

        }
    }
}