namespace SendMail.Client
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    #endregion

    public static class CommandExtensions
    {
        #region Public Methods and Operators

        private static readonly string CommandsQueue = Settings.CommandsQueue;

        public static async Task Execute(this Command command, Dictionary<string, object> metadata = null)
        {
            var commandId = Guid.NewGuid();
            
            if (metadata == null)
            {
                metadata = Settings.NewMetadata(commandId, commandId);
            }

            await Settings.Dispatch(CommandsQueue, commandId, command, metadata);
        }

        #endregion
    }
}