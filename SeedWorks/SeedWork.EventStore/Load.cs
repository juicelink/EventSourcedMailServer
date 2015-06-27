namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::EventStore.ClientAPI;

    #endregion

    public static class Load
    {
        #region Public Methods and Operators

        public static async Task<Events> Stream(string streamName, bool resolveLinks)
        {
            var events = await LoadResolvedEventsFromStream(streamName, resolveLinks);
            return new Events(events.Events.Select(Serialization.DeserializeResolvedEvent), events.LastEventNumber);
        }

        public static Task<Events> Stream(string streamName)
        {
            return Stream(streamName, false);
        }

        public static async Task<IEnumerable<T>> Stream<T>(string streamName, bool resolveLinks = false)
        {
            var events = await LoadResolvedEventsFromStream(streamName, resolveLinks);
            return events.Events.Select(Serialization.DeserializeResolvedEvent<T>);
        }

        public static async Task<IEnumerable<EventWithMetadata>> StreamWithMetaData(string streamName, bool resolveLinks = false)
        {
            var events = await LoadResolvedEventsFromStream(streamName, resolveLinks);
            return events.Events.Select(Serialization.DeserializeResolvedEventWithMetadata);
        }

        public static async Task<IEnumerable<EventWithMetadata<T>>> StreamWithMetaData<T>(string streamName, bool resolveLinks = false)
        {
            var events = await LoadResolvedEventsFromStream(streamName, resolveLinks);
            return events.Events.Select(Serialization.DeserializeResolvedEventWithMetadata<T>);
        }

        #endregion

        #region Methods

        private static async Task<ResolvedEvents> LoadResolvedEventsFromStream(string streamName, bool resolveLinks = false)
        {
            var slice = await Connection.Instance.ReadStreamEventsForwardAsync(streamName, StreamPosition.Start, Int32.MaxValue, resolveLinks, Connection.Credentials);
            return new ResolvedEvents(slice.Events, slice.LastEventNumber);
        }

        #endregion

        

        private struct ResolvedEvents
        {
            #region Constructors and Destructors

            public ResolvedEvents(ResolvedEvent[] events, int lastEventNumber)
                : this()
            {
                this.Events = events;
                this.LastEventNumber = lastEventNumber;
            }

            #endregion

            #region Public Properties

            public ResolvedEvent[] Events { get; private set; }

            public int LastEventNumber { get; private set; }

            #endregion
        }
    }
}