namespace SeedWork.EventStore
{
    #region using

    using System;

    using global::EventStore.ClientAPI;

    using SeedWork.Utils;
    using SeedWork.Utils.Logging;

    #endregion

    public class Logger : ILogger
    {
        #region Fields

        private readonly ILog log = typeof(Logger).Log();

        #endregion

        #region Public Methods and Operators

        public void Debug(string format, params object[] args)
        {
            this.log.DebugFormat(format, args);
        }

        public void Debug(Exception ex, string format, params object[] args)
        {
            this.log.DebugFormat(ex, format, args);
        }

        public void Error(string format, params object[] args)
        {
            this.log.ErrorFormat(format, args);
        }

        public void Error(Exception ex, string format, params object[] args)
        {
            this.log.ErrorFormat(ex, format, args);
        }

        public void Info(string format, params object[] args)
        {
            this.log.InfoFormat(format, args);
        }

        public void Info(Exception ex, string format, params object[] args)
        {
            this.log.InfoFormat(ex, format, args);
        }

        #endregion
    }
}