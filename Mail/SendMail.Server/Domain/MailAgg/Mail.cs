namespace SendMail.Server.Domain.MailAgg
{
    #region using

    using System.Threading.Tasks;

    using SeedWork.EventSourced;

    using SendMail.Client.Mail.Commands;
    using SendMail.Client.Mail.Events;
    using SendMail.Server.Domain.MailAgg.State;
    using SendMail.Server.Domain.MailAgg.State.RequestState;

    #endregion

    public class Mail : AggregateRoot<MailState>
    {
        #region Public Methods and Operators

        public void RequestMail(SendMail command)
        {
            this.State.RequestState.CanRequest();
            this.Raise(new MailRequested(command.Id, command.From, command.To, command.Subject, command.Body));
        }

        public void RetryMail()
        {
            this.State.RequestState.CanRetry();
            this.Raise(new MailRetried(this.State.Id));
        }

        public async Task SendMail(IMailService service)
        {
            this.State.RequestState.CanSend();
            var result = await service.Send(this.State.Request);
            if (result.Ok)
            {
                this.Raise(new MailSent(this.State.Id));
            }
            else
            {
                this.Raise(new MailFailed(this.State.Id, result.ErrorMsg));
            }
        }

        #endregion

        #region Methods

        public void Apply(MailFailed @event)
        {
            this.State.RequestState = new FailedState();
        }

        public void Apply(MailSent @event)
        {
            this.State.RequestState = new SentState();
        }

        public void Apply(MailRetried @event)
        {
            this.State.RequestState = new RetriedState();
        }

        public void Apply(MailRequested @event)
        {
            this.State.RequestState = new RequestedState();
            this.State.Request = new MailRequest(@event.From, @event.To, @event.Subject, @event.Body);
            this.State.Id = @event.Id;
        }

        #endregion
    }
}