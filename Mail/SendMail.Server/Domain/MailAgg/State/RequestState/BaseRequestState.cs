namespace SendMail.Server.Domain.MailAgg.State.RequestState
{
    #region using

    using System;

    #endregion

    public abstract class BaseRequestState
    {
        #region Public Methods and Operators

        public virtual void CanRequest()
        {
            throw this.GetException("CanRequest");
        }

        public virtual void CanRetry()
        {
            throw this.GetException("CanRetry");
        }

        public virtual void CanSend()
        {
            throw this.GetException("CanSend");
        }

        #endregion

        #region Methods

        private Exception GetException(string action)
        {
            return new Exception(string.Format("{0} action not authorized in {1}", action, this.GetType().Name));
        }

        #endregion
    }
}