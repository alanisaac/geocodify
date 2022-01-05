using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Geodata.Utilities;

namespace Geodata.MapQuest
{
    /// <summary>
    /// Provides geodata from MapQuest.
    /// </summary>
    /// <remarks>
    /// See https://developer.mapquest.com
    /// </remarks>
    public class MapQuestProvider : IGeocoder
    {
        private const string BaseUrl = "http://www.mapquestapi.com/";
        private readonly string _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapQuestProvider"/> class.
        /// </summary>
        /// <param name="key">The MapQuest API key.</param>
        public MapQuestProvider(string key)
        {
            Guard.ArgumentNotNullOrWhitespace(key, nameof(key));

            _key = key;
        }

        /// <summary>
        /// Finds the possible matches of latitude / longitude coordinates for a given address.
        /// </summary>
        /// <param name="request">The geocode request.</param>
        /// <returns>The response from this geocoding provider.</returns>
        public async Task<GeocodeResponse> Geocode(GeocodeRequest request)
        {
            var mapQuestRequest = ConvertRequest(request);
            var mapQuestResponse = await Geocode(mapQuestRequest);
            var response = ConvertResponse(mapQuestResponse);
            return response;
        }

        /// <summary>
        /// Finds the possible matches of latitude / longitude coordinates for a given address.
        /// </summary>
        /// <param name="request">The geocode request.</param>
        /// <returns>The response from this geocoding provider.</returns>
        public async Task<MapQuestGeocodeResponse> Geocode(MapQuestGeocodeRequest request)
        {
            var flurlResponse = await BaseUrl
                .AppendPathSegments("geocoding", "v1", "address")
                .SetQueryParams(new
                {
                    key = _key,
                })
                .WithCamelCaseSerialization()
                .PostJsonAsync(request);

            var response = await flurlResponse.GetJsonAsync<MapQuestGeocodeResponse>();
            return response;
        }

        private static MapQuestGeocodeRequest ConvertRequest(GeocodeRequest request)
        {
            return new MapQuestGeocodeRequest
            {
                Location = request.Address
            };
        }

        private static GeocodeResponse ConvertResponse(MapQuestGeocodeResponse response)
        {
            var results = new List<GeocodeResult>();

            foreach (var result in response.Results)
            {
                foreach (var location in result.Locations)
                {
                    var geocodeResult = new GeocodeResult
                    {
                        Address = new Address
                        {
                            Raw = location.Street
                        },
                        Coordinates = new Coordinates(location.LatLng.Lat, location.LatLng.Lng)
                    };

                    results.Add(geocodeResult);
                }
            }

            return new GeocodeResponse
            {
                Results = results
            };
        }
    }
}
