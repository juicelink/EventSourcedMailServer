namespace SendMail.Client
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    #endregion

    public interface IDispatcher
    {
        #region Public Methods and Operators

        Task Dispatch(Command command, Dictionary<string, object> metadata);

        Dictionary<string, object> NewMetadata(Guid correlationId, Guid causedBy);

        void Register(string prefix, params Type[] types);

        #endregion
    }

    public class Dispatcher : IDispatcher
    {
        public Task Dispatch(Command command, Dictionary<string, object> metadata)
        {
            throw new NotImplementedException();
        }

        public Dictionary<string, object> NewMetadata(Guid correlationId, Guid causedBy)
        {
            throw new NotImplementedException();
        }

        public void Register(string prefix, params Type[] types)
        {
            throw new NotImplementedException();
        }
    }
}