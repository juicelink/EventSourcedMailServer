namespace SeedWork.EventStore
{
    #region using

    using System.Threading.Tasks;

    using global::EventStore.ClientAPI;

    #endregion

    public static class Projection
    {
        #region Static Fields

        private static readonly ProjectionsManager Manager = new ProjectionsManager(new Logger(), Connection.EndPoint);

        #endregion

        #region Public Methods and Operators

        public static async Task SetContinuous(string name, string projection)
        {
            var currentQuery = await Manager.GetQueryAsync(name, Connection.Credentials);
            if (currentQuery == projection)
            {
                return;
            }
            await Manager.UpdateQueryAsync(name, projection, Connection.Credentials);
        }

        #endregion
    }
}