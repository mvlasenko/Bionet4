using Bionet4.Data.Contracts;
using Bionet4.Data.Models;

namespace Bionet4.Data.Repository
{
    public class EventsRepository: RepositoryBase<Event, int>, IEventsRepository
    {
        public EventsRepository(IDbContextFactory factory) : base(factory)
        {
        }
    }
}