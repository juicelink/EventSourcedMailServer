namespace SendMail.Client.Mail.Views
{
    #region using

    using System;

    #endregion

    public class MailView
    {
        #region Public Properties

        public string Body { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateUpdated { get; set; }

        public string ErrorMessage { get; set; }

        public bool Failed { get; set; }

        public string From { get; set; }

        public Guid Id { get; set; }

        public int NbTries { get; set; }

        public bool Sent { get; set; }

        public string Subject { get; set; }

        public string To { get; set; }

        #endregion
    }
}