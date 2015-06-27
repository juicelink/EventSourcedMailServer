namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class AggregateRepository : IAggregateRepository
    {
        private readonly IEventSourcedRepository eventSourcedRepo;
        private readonly string stream;

        private readonly Dictionary<string, object> metadata;

        public AggregateRepository(IEventSourcedRepository eventSourcedRepo, string stream, Dictionary<string, object> metadata)
        {
            this.eventSourcedRepo = eventSourcedRepo;
            this.stream = stream;
            this.metadata = metadata;
        }

        public Task Create(IEnumerable<object> events)
        {
            return this.eventSourcedRepo.Create(stream, events, this.metadata);
        }

        public Task Update(IEnumerable<object> events)
        {
            return this.eventSourcedRepo.Update(stream, events, this.metadata);
        }

        public Task Update(IEnumerable<object> events, int version)
        {
            return this.eventSourcedRepo.Update(stream, events, this.metadata, version);
        }

        public Task<Events> Get()
        {
            return this.eventSourcedRepo.Get(stream);
        }
    }
}