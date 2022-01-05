using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Geodata.Utilities
{
    /// <summary>
    /// Utilities for helping with serialization
    /// </summary>
    internal static class SerializationUtilities
    {
        private static readonly NewtonsoftJsonSerializer Serializer = new NewtonsoftJsonSerializer(new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        public static IFlurlRequest WithCamelCaseSerialization(this Url flurlRequest)
        {
            return flurlRequest.ConfigureRequest(settings => settings.JsonSerializer = Serializer);
        }
    }
}
