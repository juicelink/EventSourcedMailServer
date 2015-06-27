namespace SendMail.Client
{
    #region using

    using System;

    #endregion

    public abstract class Event
    {
        #region Constructors and Destructors

        protected Event(Guid id)
        {
            this.Id = id;
        }

        #endregion

        #region Public Properties

        public Guid Id { get; private set; }

        #endregion
    }
}