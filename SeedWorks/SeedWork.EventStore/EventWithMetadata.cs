namespace SeedWork.EventStore
{
    #region using

    using System.Collections.Generic;

    #endregion

    public struct EventWithMetadata
    {
        #region Constructors and Destructors

        public EventWithMetadata(object @event, Dictionary<string, object> metadata)
            : this()
        {
            this.Event = @event;
            this.Metadata = metadata;
        }

        #endregion

        #region Public Properties

        public object Event { get; private set; }

        public Dictionary<string, object> Metadata { get; private set; }

        #endregion
    }

    public struct EventWithMetadata<T>
    {
        #region Constructors and Destructors

        public EventWithMetadata(T @event, Dictionary<string, object> metadata)
            : this()
        {
            this.Event = @event;
            this.Metadata = metadata;
        }

        #endregion

        #region Public Properties

        public T Event { get; private set; }

        public Dictionary<string, object> Metadata { get; private set; }

        #endregion
    }

}