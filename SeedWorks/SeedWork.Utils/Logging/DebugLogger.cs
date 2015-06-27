namespace SeedWork.Utils.Logging
{
    #region using

    using System;

    #endregion

    public class DebugLogger : ILog
    {
        #region Constants

        private const string DEBUG = "DEBUG: ";

        private const string ERROR = "ERROR: ";

        private const string FATAL = "FATAL: ";

        private const string INFO = "INFO: ";

        private const string WARN = "WARN: ";

        #endregion

        #region Fields

        private readonly Type type;

        #endregion

        #region Constructors and Destructors

        public DebugLogger(Type type)
        {
            this.type = type;
        }

        #endregion

        #region Public Methods and Operators

        public void Debug(object message)
        {
            this.Log(DEBUG + message);
        }

        public void Debug(Exception exception, object message)
        {
            this.Log(DEBUG + message);
        }

        public void DebugFormat(string format, params object[] args)
        {
            LogFormat(DEBUG + format, args);
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            LogFormat(exception, DEBUG + format, args);
        }

        public void Error(object message)
        {
            this.Log(ERROR + message);
        }

        public void Error(Exception exception, object message)
        {
            this.Log(exception, ERROR + message);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            LogFormat(ERROR + format, args);
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            LogFormat(exception, ERROR + format, args);
        }

        public void Fatal(object message)
        {
            this.Log(FATAL + message);
        }

        public void Fatal(Exception exception, object message)
        {
            this.Log(exception, FATAL + message);
        }

        public void FatalFormat(string format, params object[] args)
        {
            LogFormat(FATAL + format, args);
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            LogFormat(exception, ERROR + format, args);
        }

        public void Info(object message)
        {
            this.Log(INFO + message);
        }

        public void Info(Exception exception, object message)
        {
            this.Log(exception, INFO + message);
        }

        public void InfoFormat(string format, params object[] args)
        {
            LogFormat(INFO + format, args);
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            LogFormat(exception, INFO + format, args);
        }

        public void Warn(object message)
        {
            this.Log(WARN + message);
        }

        public void Warn(Exception exception, object message)
        {
            this.Log(exception, WARN + message);
        }

        public void WarnFormat(string format, params object[] args)
        {
            LogFormat(WARN + format, args);
        }

        public void WarnFormat(Exception exception, string format, params object[] args)
        {
            LogFormat(exception, WARN + format, args);
        }

        #endregion

        #region Methods

        private static string GetExceptionMessage(Exception exception)
        {
            return exception == null ? string.Empty : ", Exception: " + exception.Message;
        }

        private string GetMessage(object message)
        {
            var msg = string.Format("[{0}] ", this.type.FullName);
            msg += message == null ? string.Empty : message.ToString();
            return msg;
        }

        private void Log(Exception exception, object message)
        {
            var msg = this.GetMessage(message) + GetExceptionMessage(exception);
            System.Diagnostics.Debug.WriteLine(msg);
        }

        private void Log(object message)
        {
            var msg = this.GetMessage(message);
            System.Diagnostics.Debug.WriteLine(msg);
        }

        private void LogFormat(Exception exception, object message, params object[] args)
        {
            var msg = this.GetMessage(message);
            System.Diagnostics.Debug.WriteLine(string.Format(msg, args) + GetExceptionMessage(exception));
        }

        private void LogFormat(object message, params object[] args)
        {
            var msg = this.GetMessage(message);
            System.Diagnostics.Debug.WriteLine(msg, args);
        }

        #endregion
    }
}