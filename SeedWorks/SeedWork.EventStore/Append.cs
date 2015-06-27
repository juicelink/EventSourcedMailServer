namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::EventStore.ClientAPI;
    using global::EventStore.ClientAPI.Common.Utils;

    #endregion

    public static class Append
    {
        #region Public Methods and Operators

        public static EventData NewEventData(object @event, Dictionary<string, object> metadata, string typeName)
        {
            return NewEventData(Guid.NewGuid(), @event, metadata, typeName);
        }

        public static EventData NewEventData(Guid id, object @event, Dictionary<string, object> metadata)
        {
            return NewEventData(id, @event, metadata, Serialization.GetTypeName(@event));
        }

        public static EventData NewEventData(
            Guid id,
            object @event,
            Dictionary<string, object> metadata,
            string typeName)
        {
            byte[] meta = null;
            if (metadata != null)
            {
                var storedMeta = new Dictionary<string, object>(metadata);
                storedMeta["eventId"] = id;
                storedMeta["dateCreated"] = DateTime.UtcNow;
                meta = storedMeta.ToJsonBytes();   
            }

            return new EventData(id, typeName, true, @event.ToJsonBytes(), meta);
        }

        public static Task ToNewStream(string stream, IEnumerable<object> events, Dictionary<string, object> metadata)
        {
            return ToStream(stream, events, metadata, ExpectedVersion.NoStream);
        }

        public static Task ToStream(
            string stream,
            IEnumerable<object> events,
            Dictionary<string, object> metadata,
            int expectedVersion)
        {
            var eventDatas = events.Select(e => NewEventData(Guid.NewGuid(), e, metadata));
            return ToStream(stream, eventDatas, expectedVersion);
        }

        public static Task ToStream(string stream, IEnumerable<object> events, Dictionary<string, object> metadata)
        {
            return ToStream(stream, events, metadata, ExpectedVersion.Any);
        }

        public static Task ToStream(
            string stream,
            Guid id,
            object @event,
            Dictionary<string, object> metadata,
            int expectedVersion)
        {
            var eventData = NewEventData(id, @event, metadata);
            return ToStream(stream, eventData, expectedVersion);
        }

        public static Task ToStream(
            string stream,
            Guid id,
            object @event,
            Dictionary<string, object> metadata)
        {
            return ToStream(stream, id, @event, metadata, ExpectedVersion.Any);
        }

        public static Task ToStream(
            string stream,
            object @event,
            Dictionary<string, object> metadata,
            int expectedVersion = ExpectedVersion.Any)
        {
            return ToStream(stream, Guid.NewGuid(), @event, metadata, expectedVersion);
        }

        public static Task ToStream(
            string stream,
            IEnumerable<EventData> events,
            int expectedVersion = ExpectedVersion.Any)
        {
            return Connection.Instance.AppendToStreamAsync(stream, expectedVersion, events, Connection.Credentials);
        }

        public static Task ToStream(string stream, EventData @event, int expectedVersion = ExpectedVersion.Any)
        {
            return ToStream(stream, new[] { @event }, expectedVersion);
        }

        #endregion
    }
}