using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ExactOnline.Client.OAuth
{
    /// <summary>
    /// based on http://skrift.io/articles/archive/bulletproof-interface-deserialization-in-jsonnet/
    /// </summary>
    internal class AuthorizationStateConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DotNetOpenAuth.OAuth2.IAuthorizationState);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var authorizationState = new DotNetOpenAuth.OAuth2.AuthorizationState();
            serializer.Populate(jsonObject.CreateReader(), authorizationState);
            return authorizationState;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}