namespace SendMail.Client.Mail.Commands
{
    #region using

    using System;

    #endregion

    public class RetryMail : Command
    {
        #region Constructors and Destructors

        public RetryMail(Guid id)
            : base(id)
        {
        }

        #endregion
    }
}