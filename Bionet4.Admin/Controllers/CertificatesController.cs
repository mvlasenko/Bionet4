using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Admin.Controllers
{
    public class CertificatesController : ApplicationController<Certificate, int>
    {
        private ICertificatesRepository repository;

        public CertificatesController(ICertificatesRepository repository) : base(repository)
        {
            this.repository = repository;
        }
    }
}
