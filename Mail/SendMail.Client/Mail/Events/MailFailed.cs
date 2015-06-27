namespace SendMail.Client.Mail.Events
{
    #region using

    using System;

    #endregion

    public class MailFailed : Event
    {
        #region Constructors and Destructors

        public MailFailed(Guid id, string errMsg)
            : base(id)
        {
            this.ErrMsg = errMsg;
        }

        #endregion

        #region Public Properties

        public string ErrMsg { get; private set; }

        #endregion
    }
}