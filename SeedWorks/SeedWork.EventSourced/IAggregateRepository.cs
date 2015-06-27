namespace SeedWork.EventSourced
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAggregateRepository
    {
        Task Create(IEnumerable<object> events);
        Task Update(IEnumerable<object> events);
        Task Update(IEnumerable<object> events, int version);

        Task<Events> Get();
    }
}