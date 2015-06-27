namespace SendMail.Server.Domain.MailAgg
{
    public struct SendMailResult
    {
        #region Constructors and Destructors

        public SendMailResult(bool ok, string errorMsg)
            : this()
        {
            this.Ok = ok;
            this.ErrorMsg = errorMsg;
        }

        #endregion

        #region Public Properties

        public string ErrorMsg { get; private set; }

        public bool Ok { get; private set; }

        #endregion
    }
}