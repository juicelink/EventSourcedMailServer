using System;
using System.Linq;

namespace SeedWork.EventSourced
{
    #region using

    using System.Collections.Generic;

    #endregion

    public abstract class AggregateRoot<TState>
        where TState : new()
    {
        #region Fields

        protected TState State = new TState();

        private readonly Queue<object> newEvents = new Queue<object>();

        private readonly dynamic that;

        #endregion

        protected AggregateRoot()
        {
            that = this;
        }

        #region Public Methods and Operators

        public void LoadFromHistory(IEnumerable<object> events)
        {
            foreach (dynamic @event in events)
            {
                that.Apply(@event);
            }
        }

        public IEnumerable<object> RaiseNewEvents()
        {
            var events = newEvents.ToList();
            newEvents.Clear();
            return events;
        }

        #endregion

        #region Methods

        protected void Raise<T>(T @event)
        {
            this.newEvents.Enqueue(@event);
            that.Apply(@event);
        }

        private static void Apply(object @event)
        {
            throw new Exception(string.Format("{0} event not supported yet", @event.GetType()));
        }

        #endregion
    }
}