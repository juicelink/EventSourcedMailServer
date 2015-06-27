namespace SeedWork.Utils.Logging
{
    using System;

    public interface ILogFactory
    {
        ILog GetLogger(Type type);
    }
}