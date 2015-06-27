namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Collections.Generic;

    #endregion

    public static class MessageMetadata
    {
        #region Constructors and Destructors

        public static Dictionary<string, object> New(Guid correlationId, Guid causedBy)
        {
            var meta = new Dictionary<string, object>();
            meta["$correlationId"] = correlationId;
            meta["$causedBy"] = causedBy;
            return meta;
        }

        public static Dictionary<string, object> New(Dictionary<string, object> causationMetadata)
        {
            return New(causationMetadata.CorrelationId(), causationMetadata.CausedBy());
        }

        public static void Cast(this Dictionary<string, object> metadata)
        {
            metadata["eventId"] = new Guid((string)metadata["eventId"]);
            metadata["$correlationId"] = new Guid((string)metadata["$correlationId"]);
            metadata["$causedBy"] = new Guid((string)metadata["$causedBy"]);
        }

        public static Guid CorrelationId(this Dictionary<string, object> metadata)
        {
            return (Guid)metadata["$correlationId"];
        }

        public static Guid CausedBy(this Dictionary<string, object> metadata)
        {
            return (Guid)metadata["$causedBy"];
        }

        public static Guid EventId(this Dictionary<string, object> metadata)
        {
            return (Guid)metadata["eventId"];
        }

        public static DateTime DateCreated(this Dictionary<string, object> metadata)
        {
            return (DateTime)metadata["dateCreated"];
        }

        #endregion
    }
}