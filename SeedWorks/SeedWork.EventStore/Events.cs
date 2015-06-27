namespace SeedWork.EventStore
{
    #region using

    using System.Collections.Generic;

    #endregion

    public struct Events
    {
        #region Constructors and Destructors

        public Events(IEnumerable<object> events, int lastEventNumber)
            : this()
        {
            this.List = events;
            this.LastEventNumber = lastEventNumber;
        }

        #endregion

        #region Public Properties

        public int LastEventNumber { get; private set; }

        public IEnumerable<object> List { get; private set; }

        #endregion
    }
}