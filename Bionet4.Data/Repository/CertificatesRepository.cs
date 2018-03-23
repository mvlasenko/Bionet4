using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class CertificatesRepository: RepositoryBase<Certificate, int>, ICertificatesRepository
    {
        public CertificatesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}