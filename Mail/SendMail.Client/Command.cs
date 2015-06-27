namespace SendMail.Client
{
    #region using

    using System;

    #endregion

    public abstract class Command
    {
        #region Constructors and Destructors

        protected Command(Guid id)
        {
            this.Id = id;
        }

        #endregion

        #region Public Properties

        public Guid Id { get; private set; }

        #endregion
    }
}