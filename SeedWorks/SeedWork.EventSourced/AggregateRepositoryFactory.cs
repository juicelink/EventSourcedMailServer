namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;

    public class AggregateRepositoryFactory : IAggregateRepositoryFactory
    {
        private readonly IEventSourcedRepository repository;

        public AggregateRepositoryFactory(IEventSourcedRepository repository)
        {
            this.repository = repository;
        }

        #region Implementation of IAggregateRepositoryFactory

        public IAggregateRepository New(string streamPrefix, string aggName, Guid aggId, Dictionary<string, object> metadata)
        {
            return new AggregateRepository(this.repository,string.Format("{0}.Agg.{1}-{2}", streamPrefix, aggName, aggId.ToString("N")),metadata);
        }

        #endregion
    }
}