namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using global::EventStore.ClientAPI;
    using global::EventStore.ClientAPI.Common.Utils;

    using SeedWork.Utils;
    using SeedWork.Utils.Logging;

    #endregion

    public static class Subscribe
    {       
        #region Public Methods and Operators

        private static readonly ILog Log = typeof(Subscribe).Log();

        public static async Task<Action<int>> ToCheckPointedStream(string stream, string subscriberId, Func<object, Dictionary<string, object>, Task> handle, bool resolveLinks)
        {
            var subscriber = string.IsNullOrEmpty(subscriberId) ? string.Empty : subscriberId + ".";
            var checkPointStream = string.Format("{0}.{1}ChekPoint",stream, subscriber);
            var errorStream = string.Format("{0}.{1}Error", stream, subscriber);
            Action<EventStoreCatchUpSubscription, ResolvedEvent> eventAppeared = async (catchUp, resolvedEvent) => await MessageAppeared(errorStream, checkPointStream, handle, resolvedEvent);
            var checkPoint = await GetSubscriptionCheckPoint(checkPointStream);
            var catchup = Connection.Instance.SubscribeToStreamFrom(stream, checkPoint, resolveLinks, eventAppeared);
            return new Action<int>(seconds => catchup.Stop(new TimeSpan(0, 0, seconds)));
        }

        public static Task<Action<int>> ToCheckPointedStream(
            string stream,
            string subscriberId,
            Func<object, Dictionary<string, object>, Task> handle)
        {
            return ToCheckPointedStream(stream, subscriberId, handle, false);
        }

        #endregion

        #region Methods

        private static async Task MessageAppeared(string errorStream, string chekPointStream, Func<object, Dictionary<string, object>, Task> handle, ResolvedEvent @event)
        {           
            try
            {
                var eventWithMeta = Serialization.DeserializeResolvedEventWithMetadata(@event);
                var causationMetadata = eventWithMeta.Metadata;
                causationMetadata.Cast();
                
                Exception error = null;
                try
                {
                    await handle(eventWithMeta.Event, causationMetadata);
                }
                catch (Exception ex)
                {
                    Log.ErrorFormat(ex, "error handling message id {0}", @event.Event.EventId);
                    error = ex;
                }

                if (error != null)
                {
                    var eventData = Append.NewEventData(error.Message, MessageMetadata.New(causationMetadata), "handleError");
                    await Append.ToStream(errorStream, eventData);
                }

                await SetCheckPoint(chekPointStream, @event.OriginalEventNumber);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(ex, "error when event {0} id {1} appeared on stream checkPointed by {2}", @event.GetType(), @event.Event.EventId, chekPointStream);
            }
        }

        private static async Task<int?> GetSubscriptionCheckPoint(string checkPointStream)
        {
            var metadata = new Dictionary<string, int> { { "$maxCount", 1 } }.ToJsonBytes();
            await Connection.Instance.SetStreamMetadataAsync(checkPointStream, ExpectedVersion.Any, metadata, Connection.Credentials);

            var events = await Load.Stream<int?>(checkPointStream);
            return events.LastOrDefault();
        }

        private static Task SetCheckPoint(string chekPointStream, int position)
        {
            var eventData = Append.NewEventData(position, null, "CheckPoint");
            return Append.ToStream(chekPointStream, eventData);
        }

        #endregion
    }
}