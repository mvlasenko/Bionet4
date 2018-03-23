using System.Web.Mvc;
using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers.Api
{
    public class CertificatesController : ApiController<Certificate, int>
    {
        public CertificatesController() : base(DependencyResolver.Current.GetService<ICertificatesRepository>())
        {

        }
    }
}