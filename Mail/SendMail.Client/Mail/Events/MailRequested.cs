namespace SendMail.Client.Mail.Events
{
    #region using

    using System;

    #endregion

    public class MailRequested : Event
    {
        #region Constructors and Destructors

        public MailRequested(Guid id, string from, string[] to, string subject, string body)
            : base(id)
        {
            this.From = @from;
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }

        #endregion

        #region Public Properties

        public string Body { get; private set; }

        public string From { get; private set; }

        public string Subject { get; private set; }

        public string[] To { get; private set; }

        #endregion
    }
}