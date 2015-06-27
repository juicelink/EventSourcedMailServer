using System.Runtime.CompilerServices;

namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class AggregateHandlers
    {
        private readonly string streamPrefix;
        private readonly IAggregateRepositoryFactory repoFactory;

        private readonly dynamic that;

        protected AggregateHandlers(string streamPrefix, IAggregateRepositoryFactory repoFactory)
        {
            this.streamPrefix = streamPrefix;
            this.repoFactory = repoFactory;
            that = this;
        }

        public Task Handle(dynamic command, Dictionary<string,object> metadata)
        {
            var repo = repoFactory.New(streamPrefix, this.AggName, command.Id, metadata);
            return that.Handle(command, repo);
        }

        private static Task Handle(object command, IAggregateRepository repository)
        {
            throw new Exception(string.Format("unknown {0} command", command.GetType()));
        }

        protected abstract string AggName { get; }
    }
}
