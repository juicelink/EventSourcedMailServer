namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Net;

    using global::EventStore.ClientAPI;
    using global::EventStore.ClientAPI.SystemData;

    using SeedWork.EventStore.Properties;

    #endregion

    public static class Connection
    {
        #region Static Fields

        private static readonly Lazy<IEventStoreConnection> LazyConnection = new Lazy<IEventStoreConnection>(GetInstance);

        #endregion

        #region Constructors and Destructors

        static Connection()
        {
            Credentials = new UserCredentials(Settings.Default.login, Settings.Default.password);
            EndPoint = new IPEndPoint(IPAddress.Parse(Settings.Default.ipAddress), 1113);
        }

        #endregion

        #region Public Properties

        public static UserCredentials Credentials { get; private set; }

        public static IPEndPoint EndPoint { get; private set; }

        public static IEventStoreConnection Instance
        {
            get
            {
                return LazyConnection.Value;
            }
        }

        #endregion

        #region Methods

        private static IEventStoreConnection GetInstance()
        {
            var cnn = EventStoreConnection.Create(EndPoint);
            cnn.Connect();
            return cnn;
        }

        #endregion
    }
}