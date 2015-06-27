namespace SeedWork.Log4Net
{
    #region using

    using System;

    using log4net;

    using ILog = SeedWork.Utils.Logging.ILog;

    #endregion

    public class Log4NetLogger : ILog
    {
        #region Fields

        private readonly log4net.ILog log;

        #endregion

        #region Constructors and Destructors

        public Log4NetLogger(Type type)
        {
            this.log = LogManager.GetLogger(type);
        }

        #endregion

        #region Public Methods and Operators

        public void Debug(object message)
        {
            if (!this.log.IsDebugEnabled)
            {
                return;
            }
            this.log.Debug(message);
        }

        public void Debug(Exception exception, object message)
        {
            if (!this.log.IsDebugEnabled)
            {
                return;
            }
            this.log.Debug(message, exception);
        }

        public void DebugFormat(string format, params object[] args)
        {
            if (!this.log.IsDebugEnabled)
            {
                return;
            }
            this.log.DebugFormat(format, args);
        }

        public void DebugFormat(Exception exception, string format, params object[] args)
        {
            if (!this.log.IsDebugEnabled)
            {
                return;
            }
            this.log.Debug(string.Format(format, args), exception);
        }

        public void Error(object message)
        {
            if (!this.log.IsErrorEnabled)
            {
                return;
            }
            this.log.Error(message);
        }

        public void Error(Exception exception, object message)
        {
            if (!this.log.IsErrorEnabled)
            {
                return;
            }
            this.log.Error(message, exception);
        }

        public void ErrorFormat(string format, params object[] args)
        {
            if (!this.log.IsErrorEnabled)
            {
                return;
            }
            this.log.ErrorFormat(format, args);
        }

        public void ErrorFormat(Exception exception, string format, params object[] args)
        {
            if (!this.log.IsErrorEnabled)
            {
                return;
            }
            this.log.Error(string.Format(format, args), exception);
        }

        public void Fatal(object message)
        {
            if (!this.log.IsFatalEnabled)
            {
                return;
            }
            this.log.Fatal(message);
        }

        public void Fatal(Exception exception, object message)
        {
            if (!this.log.IsFatalEnabled)
            {
                return;
            }
            this.log.Fatal(message, exception);
        }

        public void FatalFormat(string format, params object[] args)
        {
            if (!this.log.IsFatalEnabled)
            {
                return;
            }
            this.log.FatalFormat(format, args);
        }

        public void FatalFormat(Exception exception, string format, params object[] args)
        {
            if (!this.log.IsFatalEnabled)
            {
                return;
            }
            this.log.Fatal(string.Format(format, args), exception);
        }

        public void Info(object message)
        {
            if (!this.log.IsInfoEnabled)
            {
                return;
            }
            this.log.Info(message);
        }

        public void Info(Exception exception, object message)
        {
            if (!this.log.IsInfoEnabled)
            {
                return;
            }
            this.log.Info(message, exception);
        }

        public void InfoFormat(string format, params object[] args)
        {
            if (!this.log.IsInfoEnabled)
            {
                return;
            }
            this.log.InfoFormat(format, args);
        }

        public void InfoFormat(Exception exception, string format, params object[] args)
        {
            if (!this.log.IsInfoEnabled)
            {
                return;
            }
            this.log.Info(string.Format(format, args), exception);
        }

        public void Warn(object message)
        {
            if (!this.log.IsWarnEnabled)
            {
                return;
            }
            this.log.Warn(message);
        }

        public void Warn(Exception exception, object message)
        {
            if (!this.log.IsWarnEnabled)
            {
                return;
            }
            this.log.Warn(message, exception);
        }

        public void WarnFormat(string format, params object[] args)
        {
            if (!this.log.IsWarnEnabled)
            {
                return;
            }
            this.log.WarnFormat(format, args);
        }

        public void WarnFormat(Exception exception, string format, params object[] args)
        {
            if (!this.log.IsWarnEnabled)
            {
                return;
            }
            this.log.Warn(string.Format(format, args), exception);
        }

        #endregion
    }
}