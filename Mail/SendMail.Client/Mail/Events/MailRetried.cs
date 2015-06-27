namespace SendMail.Client.Mail.Events
{
    #region using

    using System;

    #endregion

    public class MailRetried : Event
    {
        #region Constructors and Destructors

        public MailRetried(Guid id)
            : base(id)
        {
        }

        #endregion
    }
}