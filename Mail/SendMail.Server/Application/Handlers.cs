namespace SendMail.Server.Application
{
    #region using

    using SeedWork.EventSourced;

    using SendMail.Client.Mail.Commands;
    using SendMail.Server.Domain;

    #endregion

    public class Handlers : ModuleHandlers
    {
        #region Constructors and Destructors

        public Handlers(IAggregateRepositoryFactory repoFactory, IMailService mailService)
        {
            var streamPrefix = Client.Settings.ServiceStreamPrefix;
            this.RegisterCommands(new MailAgg.Handlers(streamPrefix, repoFactory, mailService), typeof(SendMail), typeof(RetryMail));
        }

        #endregion
    }
}