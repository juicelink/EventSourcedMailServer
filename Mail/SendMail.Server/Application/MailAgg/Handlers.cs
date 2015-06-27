namespace SendMail.Server.Application.MailAgg
{
    #region using

    using System.Threading.Tasks;

    using SeedWork.EventSourced;

    using SendMail.Client.Mail.Commands;
    using SendMail.Server.Domain;
    using SendMail.Server.Domain.MailAgg;
    using SendMail.Server.Properties;

    #endregion

    public class Handlers : AggregateHandlers
    {
        #region Fields

        private readonly IMailService mailService;

        #endregion

        #region Constructors and Destructors

        public Handlers(string streamPrefix, IAggregateRepositoryFactory repoFactory, IMailService mailService)
            : base(streamPrefix, repoFactory)
        {
            this.mailService = mailService;
        }

        #endregion

        #region Properties

        protected override string AggName
        {
            get
            {
                return "Mail";
            }
        }

        #endregion

        #region Public Methods and Operators

        public async Task Handle(SendMail command, IAggregateRepository repository)
        {
            var mail = new Mail();
            mail.RequestMail(command);
            await repository.Create(mail.RaiseNewEvents());
            await mail.SendMail(this.mailService);
            await repository.Update(mail.RaiseNewEvents());
        }

        public async Task Handle(RetryMail command, IAggregateRepository repository)
        {
            var mail = new Mail();
            var load = await repository.Get();
            mail.LoadFromHistory(load.List);
            mail.RetryMail();
            await repository.Update(mail.RaiseNewEvents(), load.LastEventNumber);
            await mail.SendMail(this.mailService);
            await repository.Update(mail.RaiseNewEvents());
        }

        #endregion
    }
}