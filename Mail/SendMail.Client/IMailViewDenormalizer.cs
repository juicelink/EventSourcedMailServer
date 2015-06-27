namespace SendMail.Client
{
    using System.Collections.Generic;

    using SendMail.Client.Mail.Events;

    public interface IMailViewDenormalizer
    {
        void Handle(MailFailed @event, Dictionary<string, object> metadata);

        void Handle(MailRequested @event, Dictionary<string, object> metadata);

        void Handle(MailRetried @event, Dictionary<string, object> metadata);

        void Handle(MailSent @event, Dictionary<string, object> metadata);
    }
}