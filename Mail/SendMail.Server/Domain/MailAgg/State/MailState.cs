namespace SendMail.Server.Domain.MailAgg.State
{
    #region using

    using System;

    using SendMail.Server.Domain.MailAgg.State.RequestState;

    #endregion

    public class MailState
    {
        #region Constructors and Destructors

        public MailState()
        {
            this.RequestState = new InitState();
        }

        #endregion

        #region Properties

        internal Guid Id { get; set; }

        internal MailRequest Request { get; set; }

        internal BaseRequestState RequestState { get; set; }

        #endregion
    }
}