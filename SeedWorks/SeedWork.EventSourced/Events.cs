namespace SeedWork.EventSourced
{
    using System.Collections.Generic;

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

        public IEnumerable<object> List { get; private set; }

        public int LastEventNumber { get; private set; }

        #endregion
    }
}