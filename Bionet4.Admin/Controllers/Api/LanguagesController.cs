using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class LanguagesController : ApiController<Language, int>
    {
        public LanguagesController() : base(DependencyResolver.Current.GetService<ILanguagesRepository>())
        {

        }
    }
}