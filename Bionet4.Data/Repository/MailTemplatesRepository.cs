using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class MailTemplatesRepository: RepositoryBase<MailTemplate, int>, IMailTemplatesRepository
    {
        public MailTemplatesRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}