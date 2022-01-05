namespace Geodata
{
    /// <summary>
    /// Represents an individual result of a geeocode operation.
    /// </summary>
    public class GeocodeResult
    {
        /// <summary>
        /// The address returned for this result.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// The latitude and longitude coordinates for this result.
        /// </summary>
        public Coordinates Coordinates { get; set; }
    }
}
