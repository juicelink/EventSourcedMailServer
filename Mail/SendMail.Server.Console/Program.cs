namespace SendMail.Server.Console
{
    #region using

    using System;

    #endregion

    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            Ioc.Init();
            Client.Settings.RegisterCommands();
            var stopCommands = Subscribe.ToCommands().Result;
            Client.Settings.RegisterEvents();
            var stopEvents = Subscribe.ToEvents("EF").Result;
            Console.ReadLine();
            stopCommands(30);
            stopEvents(30);
        }

        #endregion
    }
}