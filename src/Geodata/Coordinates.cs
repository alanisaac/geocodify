using System;
using Geodata.Utilities;

namespace Geodata
{
    /// <summary>
    /// Represents a location via geographic latitude and longitude.
    /// </summary>
    public struct Coordinates : IEquatable<Coordinates>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> struct.
        /// </summary>
        /// <param name="latitude">The latitude in decimal degrees. Must be between -90 and 90 inclusive.</param>
        /// <param name="longitude">The longitude in decimal degrees. Must be between -180 and 180 inclusive.</param>
        public Coordinates(double latitude, double longitude)
        {
            Guard.ArgumentNotNaN(latitude, nameof(latitude));
            Guard.ArgumentNotNaN(longitude, nameof(longitude));
            Guard.ArgumentIsBetween(latitude, -90, 90, nameof(latitude));
            Guard.ArgumentIsBetween(longitude, -180, 180, nameof(longitude));

            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        /// Gets empty coordinates with latitude and longitude at (0, 0).
        /// </summary>
        public static Coordinates Empty { get; } = new Coordinates(0, 0);

        /// <summary>
        /// Gets the latitude of the coordinates in decimal degrees.
        /// </summary>
        /// <value>
        /// The latitude.
        /// </value>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the coordinates in decimal degrees.
        /// </summary>
        /// <value>
        /// The longitude.
        /// </value>
        public double Longitude { get; }

        #region IEquatable Members

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>true if the current object is equal to the other parameter; otherwise, false.</returns>
        public bool Equals(Coordinates other)
        {
            return Longitude.Equals(other.Longitude) && Latitude.Equals(other.Latitude);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Coordinates && Equals((Coordinates)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Longitude.GetHashCode() * 397) ^ Latitude.GetHashCode();
            }
        }

        /// <summary>
        /// Implements the operator ==.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator ==(Coordinates left, Coordinates right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Implements the operator !=.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static bool operator !=(Coordinates left, Coordinates right)
        {
            return !left.Equals(right);
        }

        #endregion
    }
}
