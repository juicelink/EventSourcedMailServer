namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;

    public interface IAggregateRepositoryFactory
    {
        IAggregateRepository New(string streamPrefix, string aggName, Guid aggId, Dictionary<string, object> metadata);
    }
}