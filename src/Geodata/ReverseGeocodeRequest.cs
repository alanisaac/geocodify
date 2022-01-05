namespace Geodata
{
    /// <summary>
    /// Represents a request to a reverse geocoding provider.
    /// </summary>
    public class ReverseGeocodeRequest
    {
        /// <summary>
        /// The latitude and longitude coordinates to reverse geocode.
        /// </summary>
        public Coordinates Coordinates { get; set; }
    }
}
