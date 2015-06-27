namespace SeedWork.Utils.Logging
{
    public static class LogSettings
    {
        private static ILogFactory logFactory = new DebugLogFactory();

        /// <summary>
        /// Gets or sets the log factory.
        /// Use this to override the factory that is used to create loggers
        /// </summary>
        public static ILogFactory LogFactory
        {
            internal get
            {
                return logFactory;
            }
            set { logFactory = value; }
        }
    }
}
