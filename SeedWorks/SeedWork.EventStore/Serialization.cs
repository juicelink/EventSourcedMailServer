namespace SeedWork.EventStore
{
    #region using

    using System;
    using System.Collections.Generic;
    using System.Text;

    using global::EventStore.ClientAPI;
    using global::EventStore.ClientAPI.Common.Utils;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    #endregion

    public static class Serialization
    {
        #region Static Fields

        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver(), DateFormatHandling = DateFormatHandling.IsoDateFormat, NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore, TypeNameHandling = TypeNameHandling.None, Converters = new List<JsonConverter> { new StringEnumConverter() } };

        private static readonly Dictionary<string, Type> Types = new Dictionary<string, Type>();

        private static readonly Dictionary<Type, string> TypesNames = new Dictionary<Type, string>();

        private static readonly UTF8Encoding Utf8NoBom = new UTF8Encoding(false);

        #endregion

        #region Public Methods and Operators

        public static EventWithMetadata DeserializeResolvedEventWithMetadata(ResolvedEvent @event)
        {
            var evt = DeserializeResolvedEvent(@event);
            var meta = DeserializeMetadata(@event.Event.Metadata);
            return new EventWithMetadata(evt, meta);
        }

        public static EventWithMetadata<T> DeserializeResolvedEventWithMetadata<T>(ResolvedEvent @event)
        {
            var evt = DeserializeResolvedEvent<T>(@event);
            var meta = DeserializeMetadata(@event.Event.Metadata);
            return new EventWithMetadata<T>(evt, meta);
        }

        public static object DeserializeResolvedEvent(ResolvedEvent @event)
        {
            return DeserializeObject(@event.Event.Data, @event.Event.EventType);
        }

        public static T DeserializeResolvedEvent<T>(ResolvedEvent @event)
        {
            return DeserializeObject<T>(@event.Event.Data);
        }

        public static void Register(string typeName, Type type)
        {
            Types[typeName] = type;
            TypesNames[type] = typeName;
        }

        public static void Register<T>(string typeName)
        {
            Register(typeName, typeof(T));
        }

        public static void Register(params Type[] types)
        {
            foreach (var type in types)
            {
                Register(type.FullName, type);
            }
        }

        public static void Register(IDictionary<string, Type> types)
        {
            foreach (var type in types)
            {
                Register(type.Key, type.Value);
            }
        }

        public static void RegisterWithShortName<T>(string prefix)
        {
            var t = typeof(T);
            Register(prefix + t.Name, t);
        }

        public static void RegisterWithShortName<T>()
        {
            RegisterWithShortName<T>(string.Empty);
        }

        public static void RegisterWithShortName(string prefix, params Type[] types)
        {
            foreach (var type in types)
            {
                Register(prefix + type.Name, type);
            }
        }

        public static void RegisterWithShortName(params Type[] types)
        {
            RegisterWithShortName(string.Empty, types);
        }

        #endregion

        #region Methods

        internal static Type GetType(string name)
        {
            return Types[name];
        }

        internal static string GetTypeName(object obj)
        {
            return TypesNames[obj.GetType()];
        }

        private static Dictionary<string, object> DeserializeMetadata(byte[] metadata)
        {
            return metadata == null ? new Dictionary<string, object>() : metadata.ParseJson<Dictionary<string, object>>();
        }

        private static object DeserializeObject(byte[] data, string type)
        {
            return JsonConvert.DeserializeObject(Utf8NoBom.GetString(data), Types[type], JsonSettings);
        }

        private static T DeserializeObject<T>(byte[] data)
        {
            return JsonConvert.DeserializeObject<T>(Utf8NoBom.GetString(data), JsonSettings);
        }

        #endregion
    }
}