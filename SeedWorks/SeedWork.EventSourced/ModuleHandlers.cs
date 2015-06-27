namespace SeedWork.EventSourced
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public abstract class ModuleHandlers
    {
        #region Fields

        private readonly Dictionary<Type, AggregateHandlers> handlers = new Dictionary<Type, AggregateHandlers>();

        #endregion

        #region Public Methods and Operators

        public Task Handle(object command, Dictionary<string, object> metadata)
        {
            return this.handlers[command.GetType()].Handle(command, metadata);
        }

        #endregion

        #region Methods

        protected void RegisterCommands(AggregateHandlers handler, params Type[] commands)
        {
            foreach (var command in commands)
            {
                this.handlers[command] = handler;
            }
        }

        #endregion
    }
}