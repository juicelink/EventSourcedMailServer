namespace SendMail.Client.Console
{
    #region using

    using System;

    using SendMail.Client.Mail.Commands;

    #endregion

    internal class Program
    {
        #region Methods

        private static void Main(string[] args)
        {
            Ioc.Init();
            new SendMail("chezju@gmail.com", new[] { "chezju@gmail.com" }, "hello", "hello").Execute().Wait();
            var mails = Query.Instance.Get(m => true);
            Console.ReadLine();
        }

        #endregion
    }
}