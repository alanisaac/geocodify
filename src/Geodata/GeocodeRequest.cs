namespace Geodata
{
    /// <summary>
    /// Represents a request to a geocoding provider.
    /// </summary>
    public class GeocodeRequest
    {
        /// <summary>
        /// The address to geocode.
        /// </summary>
        public string Address { get; set; }
    }
}
