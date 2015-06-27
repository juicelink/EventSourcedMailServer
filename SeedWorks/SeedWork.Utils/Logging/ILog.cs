namespace SeedWork.Utils.Logging
{
    #region using

    using System;

    #endregion

    public interface ILog
    {

        #region Public Methods and Operators

        void Error(object message);

        void Error(Exception exception, object message);

        void ErrorFormat(string format, params object[] args);

        void ErrorFormat(Exception exception, string format, params object[] args);

        void Fatal(object message);

        void Fatal(Exception exception, object message);

        void FatalFormat(string format, params object[] args);

        void FatalFormat(Exception exception, string format, params object[] args);

        void Debug(object message);

        void Debug(Exception exception, object message);

        void DebugFormat(string format, params object[] args);

        void DebugFormat(Exception exception, string format, params object[] args);

        void Info(object message);

        void Info(Exception exception, object message);

        void InfoFormat(string format, params object[] args);

        void InfoFormat(Exception exception, string format, params object[] args);

        void Warn(object message);

        void Warn(Exception exception, object message);

        void WarnFormat(string format, params object[] args);

        void WarnFormat(Exception exception, string format, params object[] args);

        #endregion
    }
}