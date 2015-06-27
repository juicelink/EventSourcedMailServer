namespace SeedWork.Utils.Logging
{
    using System;

    public class DebugLogFactory : ILogFactory
    {

        public ILog GetLogger(Type type)
        {
            return new DebugLogger(type);
        }
    }
}