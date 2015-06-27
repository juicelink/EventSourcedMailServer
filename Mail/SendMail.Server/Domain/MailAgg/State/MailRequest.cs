namespace SendMail.Server.Domain.MailAgg.State
{
    #region using

    using System.Collections.Generic;

    #endregion

    public struct MailRequest
    {
        #region Constructors and Destructors

        public MailRequest(string from, IEnumerable<string> to, string subject, string body)
            : this()
        {
            this.From = @from;
            this.To = to;
            this.Subject = subject;
            this.Body = body;
        }

        #endregion

        #region Properties

        internal string Body { get; private set; }

        internal string From { get; private set; }

        internal string Subject { get; private set; }

        internal IEnumerable<string> To { get; private set; }

        #endregion
    }
}