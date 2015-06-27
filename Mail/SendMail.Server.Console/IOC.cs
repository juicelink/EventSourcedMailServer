namespace SendMail.Server.Console
{
    #region using

    using System.Threading.Tasks;

    using SeedWork.EventSourced;
    using SeedWork.EventStore;

    using SendMail.Client;
    using SendMail.EFReadModel;

    using EventSourcedEvents = SeedWork.EventSourced.Events;
    using EventStoreEvents = SeedWork.EventStore.Events;
    using Settings = SendMail.Server.Settings;
    using Subscribe = SeedWork.EventStore.Subscribe;

    #endregion

    public static class Ioc
    {
        #region Public Methods and Operators

        public static void Init()
        {
            Client.Settings.NewMetadata = MessageMetadata.New;
            Client.Settings.Register = Serialization.RegisterWithShortName;
            Client.Settings.Dispatch = Append.ToStream;
            Client.Settings.MailViewDenormalizer = new MailViewDenormalizer();
            Settings.EventSourcedRepository = new EventSourcedRepository(
                Append.ToNewStream,
                Append.ToStream,
                Append.ToStream,
                Load, MessageMetadata.New);
            Settings.Subscribe = Subscribe.ToCheckPointedStream;
            Query.Instance = new MailViewQuery();
        }

        #endregion

        #region Methods

        private static async Task<EventSourcedEvents> Load(string stream)
        {
            var result = await SeedWork.EventStore.Load.Stream(stream);
            return new EventSourcedEvents(result.List, result.LastEventNumber);
        }

        #endregion
    }
}