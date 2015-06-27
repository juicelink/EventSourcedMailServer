namespace SeedWork.Utils
{
    using System;

    using SeedWork.Utils.Logging;

    public static class ObjectExtensions
    {

        public static ILog Log(this Type type)
        {
            return LogSettings.LogFactory.GetLogger(type);
        }

        public static ILog Log(this Object @object)
        {
            return LogSettings.LogFactory.GetLogger(@object.GetType());
        }
    }
}