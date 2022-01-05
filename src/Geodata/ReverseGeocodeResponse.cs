using System.Collections.Generic;

namespace Geodata
{
    /// <summary>
    /// Represents a response from a reverse geocoding provider.
    /// </summary>
    public class ReverseGeocodeResponse
    {
        /// <summary>
        /// The located results of the reverse geocode operation.
        /// </summary>
        public IReadOnlyCollection<GeocodeResult> Results { get; set; }
    }
}
