namespace SendMail.EFReadModel
{
    #region using

    using System;
    using System.Collections.Generic;

    using SendMail.Client;
    using SendMail.Client.Mail.Events;
    using SendMail.Client.Mail.Views;

    #endregion

    public class MailViewDenormalizer : IMailViewDenormalizer
    {
        #region Public Methods and Operators

        public void Handle(MailFailed @event, Dictionary<string, object> metadata)
        {
            Update(@event.Id, m =>
                {
                    m.Failed = true;
                    m.ErrorMessage = @event.ErrMsg;
                }, metadata);
        }

        public void Handle(MailRequested @event, Dictionary<string, object> metadata)
        {
            using (var context = new SendMailContext())
            {
                context.MailViews.Add(new MailView { Id = @event.Id, From = @event.From, To = string.Join(";", @event.To), Subject = @event.Subject, Body = @event.Body, DateCreated = GetEventDate(metadata), NbTries = 1 });
                context.SaveChanges();
            }
        }

        public void Handle(MailRetried @event, Dictionary<string, object> metadata)
        {
            Update(@event.Id, m =>
                {
                    m.NbTries++;
                    m.Failed = false;
                    m.ErrorMessage = null;
                }, metadata);
        }

        public void Handle(MailSent @event, Dictionary<string, object> metadata)
        {
            Update(@event.Id, m => { m.Sent = true; }, metadata);
        }

        #endregion

        #region Methods

        private static DateTime GetEventDate(Dictionary<string, object> metadata)
        {
            return (DateTime)metadata["dateCreated"];
        }

        private static void Update(Guid id, Action<MailView> update, Dictionary<string, object> metadata)
        {
            using (var context = new SendMailContext())
            {
                var mail = context.MailViews.Find(id);
                update(mail);
                mail.DateUpdated = GetEventDate(metadata);
                context.SaveChanges();
            }
        }

        #endregion
    }
}