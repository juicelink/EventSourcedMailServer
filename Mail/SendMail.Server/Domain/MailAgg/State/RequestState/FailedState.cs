namespace SendMail.Server.Domain.MailAgg.State.RequestState
{
    public class FailedState : BaseRequestState
    {
        #region Public Methods and Operators

        public override void CanRetry()
        {
        }

        #endregion
    }
}