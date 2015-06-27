namespace SendMail.Client.Mail.Events
{
    #region using

    using System;

    #endregion

    public class MailSent : Event
    {
        #region Constructors and Destructors

        public MailSent(Guid id)
            : base(id)
        {
        }

        #endregion
    }
}