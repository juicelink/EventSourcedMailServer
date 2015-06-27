namespace SendMail.Client
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SendMail.Client.Mail.Commands;
    using SendMail.Client.Mail.Events;
    using SendMail.Client.Properties;

    #endregion

    public static class Settings
    {
        #region Public Properties

        public static string ServiceStreamPrefix
        {
            get
            {
                return "SendMail";
            }
        }
        
        public static string CommandsQueue
        {
            get
            {
                return ServiceStreamPrefix + ".Commands";
            }
        }

        public static string MessagePrefix
        {
            get
            {
                return ServiceStreamPrefix + "_";
            }
        }

        public static string MailViewEventsQueue
        {
            get
            {
                return ServiceStreamPrefix + ".Events.MailView";
            }
        }


        public static Func<string, Guid, Command, Dictionary<string, object>, Task> Dispatch { internal get; set; }

        public static Func<Guid, Guid, Dictionary<string, object>> NewMetadata { internal get; set; }

        public static Action<string, Type[]> Register { internal get; set; }

        public static IMailViewDenormalizer MailViewDenormalizer { get; set; }

        #endregion

        #region Public Methods and Operators

        public static void RegisterCommands()
        {
            Register(MessagePrefix, new []{typeof(SendMail), typeof(RetryMail)});
        }

        public static void RegisterEvents()
        {
            Register(MessagePrefix, new[] { typeof(MailFailed), typeof(MailRequested), typeof(MailRetried), typeof(MailSent) });
        }

        #endregion
    }
}