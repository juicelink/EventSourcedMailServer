namespace SendMail.Server
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SeedWork.EventSourced;

    using SendMail.Server.Application;

    #endregion

    public static class Subscribe
    {
        #region Static Fields

        private static readonly Lazy<ModuleHandlers> Handlers =
            new Lazy<ModuleHandlers>(
                () => new Handlers(new AggregateRepositoryFactory(Settings.EventSourcedRepository), new MailService()));

        #endregion

        #region Public Methods and Operators

        public static Task<Action<int>> ToCommands()
        {
            return Settings.Subscribe(
                Client.Settings.CommandsQueue,
                null,
                Handlers.Value.Handle, false);
        }

        public static Task<Action<int>> ToEvents(string subscriberId)
        {
            return Settings.Subscribe(Client.Settings.MailViewEventsQueue, subscriberId, HandleMailEvents,true);
        }

        #endregion

        #region Methods

        private static Task HandleMailEvents(dynamic @event, Dictionary<string, object> metadata)
        {
            Client.Settings.MailViewDenormalizer.Handle(@event, metadata);
            return Task.FromResult(0);
        }

        #endregion
    }
}