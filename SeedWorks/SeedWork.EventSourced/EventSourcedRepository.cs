namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EventSourcedRepository : IEventSourcedRepository
    {
        private readonly Func<string, IEnumerable<object>, Dictionary<string, object>, Task> create;
        private readonly Func<string, IEnumerable<object>, Dictionary<string, object>, Task> update;
        private readonly Func<string, IEnumerable<object>, Dictionary<string, object>, int, Task> updateVersioned;
        private readonly Func<string, Task<Events>> load;
        private readonly Func<Dictionary<string, object>, Dictionary<string, object>> newMetadata;

        public EventSourcedRepository(
            Func<string, IEnumerable<object>, Dictionary<string, object>, Task> create,
            Func<string, IEnumerable<object>, Dictionary<string, object>, Task> update,
            Func<string, IEnumerable<object>, Dictionary<string, object>, int, Task> updateVersioned,
            Func<string, Task<Events>> load,
            Func<Dictionary<string,object>,Dictionary<string, object>> newMetadata)
        {
            this.create = create;
            this.update = update;
            this.updateVersioned = updateVersioned;
            this.load = load;
            this.newMetadata = newMetadata;
        }

        #region Implementation of IEventSourcedRepository

        public Task Create(string stream, IEnumerable<object> events, Dictionary<string, object> metadata)
        {
            return this.create(stream, events, newMetadata(metadata));
        }

        public Task Update(string stream, IEnumerable<object> events, Dictionary<string, object> metadata)
        {
            return this.update(stream, events, newMetadata(metadata));
        }

        public Task Update(string stream, IEnumerable<object> events, Dictionary<string, object> metadata, int version)
        {
            return this.updateVersioned(stream, events, newMetadata(metadata), version);
        }

        public Task<Events> Get(string stream)
        {
            return this.load(stream);
        }

        #endregion
    }
}