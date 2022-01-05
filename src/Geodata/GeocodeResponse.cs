using System.Collections.Generic;

namespace Geodata
{
    /// <summary>
    /// Represents a response from a geocoding provider.
    /// </summary>
    public class GeocodeResponse
    {
        /// <summary>
        /// The located results of the geocode operation.
        /// </summary>
        public IReadOnlyCollection<GeocodeResult> Results { get; set; }
    }
}
