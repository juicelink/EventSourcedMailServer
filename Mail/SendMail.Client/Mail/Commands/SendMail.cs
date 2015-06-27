namespace SendMail.Client.Mail.Commands
{
    #region using

    using System;

    #endregion

    public class SendMail : Command
    {
        #region Constructors and Destructors

        public SendMail(string from, string[] to, string subject, string body)
            : base(Guid.NewGuid())
        {
            this.From = from;
            this.Subject = subject;
            this.Body = body;
            this.To = to;
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