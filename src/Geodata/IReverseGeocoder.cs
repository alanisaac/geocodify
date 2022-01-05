using System.Threading.Tasks;

namespace Geodata
{
    /// <summary>
    /// Represents a provider that supports reverse geocoding.
    /// </summary>
    public interface IReverseGeocoder
    {
        /// <summary>
        /// Finds the possible matches of latitude / longitude coordinates for a given address.
        /// </summary>
        /// <param name="request">The reverse geocode request.</param>
        /// <returns>The response from this reverse geocoding provider.</returns>
        Task<ReverseGeocodeResponse> ReverseGeocode(ReverseGeocodeRequest request);
    }
}
