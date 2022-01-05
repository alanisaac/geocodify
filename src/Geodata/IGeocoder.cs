using System.Threading.Tasks;

namespace Geodata
{
    /// <summary>
    /// Represents a provider that supports geocoding.
    /// </summary>
    public interface IGeocoder
    {
        /// <summary>
        /// Finds the possible matches of latitude / longitude coordinates for a given address.
        /// </summary>
        /// <param name="request">The geocode request.</param>
        /// <returns>The response from this geocoding provider.</returns>
        Task<GeocodeResponse> Geocode(GeocodeRequest request);
    }
}
