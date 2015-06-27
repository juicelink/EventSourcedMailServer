namespace SendMail.Server
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SeedWork.EventSourced;

    public static class Settings
    {
        public static IEventSourcedRepository EventSourcedRepository { internal get; set; }
        public static Func<string,string, Func<object, Dictionary<string, object>, Task>,bool, Task<Action<int>>> Subscribe { internal get; set; }
    }
}