namespace SeedWork.Log4Net
{
    #region using

    using System;
    using System.IO;

    using log4net;
    using log4net.Config;
    using log4net.Repository;

    using SeedWork.Utils.Logging;

    using ILog = SeedWork.Utils.Logging.ILog;

    #endregion

    public class Log4NetFactory : ILogFactory
    {
        #region Constructors and Destructors

        public Log4NetFactory()
            : this(false)
        {
        }

        public Log4NetFactory(bool configureLog4Net)
        {
            if (configureLog4Net)
            {
                XmlConfigurator.Configure();
            }
        }

        public Log4NetFactory(string log4NetConfigurationFile)
        {
            //Restart logging if necessary
            ILoggerRepository rootRepository = LogManager.GetRepository();
            if (rootRepository != null)
            {
                rootRepository.Shutdown();
            }

            if (File.Exists(log4NetConfigurationFile))
            {
                XmlConfigurator.ConfigureAndWatch(new FileInfo(log4NetConfigurationFile));
            }
            else
            {
                XmlConfigurator.Configure();
            }
        }

        #endregion

        #region Public Methods and Operators

        public ILog GetLogger(Type type)
        {
            return new Log4NetLogger(type);
        }

        #endregion
    }
}