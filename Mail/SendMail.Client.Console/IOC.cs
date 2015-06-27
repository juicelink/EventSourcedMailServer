namespace SendMail.Client.Console
{
    #region using

    using SeedWork.EventStore;

    using SendMail.Client;
    using SendMail.EFReadModel;

    #endregion

    public static class Ioc
    {
        #region Public Methods and Operators

        public static void Init()
        {
            Settings.NewMetadata = MessageMetadata.New;
            Settings.Register = Serialization.RegisterWithShortName;
            Settings.Dispatch = Append.ToStream;
            Query.Instance = new MailViewQuery();

            Settings.RegisterCommands();
        }

        #endregion
    }
}