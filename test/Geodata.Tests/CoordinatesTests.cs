using System;
using Xunit;

namespace Geodata.Tests
{
    public class CoordinatesTests
    {
        [Fact]
        public void Constructor_ThrowsIfLatitudeIsNotANumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new Coordinates(double.NaN, 0);
            });
        }

        [Fact]
        public void Constructor_ThrowsIfLatitudeIsLessThanNegative90()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _ = new Coordinates(-90.1, 0);
            });
        }

        [Fact]
        public void Constructor_ThrowsIfLatitudeIsGreaterThanPositive90()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _ = new Coordinates(90.1, 0);
            });
        }

        [Fact]
        public void Constructor_ThrowsIfLongitudeIsNotANumber()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new Coordinates(0, double.NaN);
            });
        }

        [Fact]
        public void Constructor_ThrowsIfLongitudeIsLessThanNegative180()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _ = new Coordinates(0, -180.1);
            });
        }

        [Fact]
        public void Constructor_ThrowsIfLongitudeIsGreaterThanPositive180()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _ = new Coordinates(0, 180.1);
            });
        }

        [Fact]
        public void EmptyCoordinates_HasBothLatitudeAndLongitudeOfZero()
        {
            var empty = Coordinates.Empty;

            Assert.Equal(0d, empty.Latitude, 6);
            Assert.Equal(0d, empty.Longitude, 6);
        }

        [Fact]
        public void CoordinatesWithSameLongitudeAndLatitude_AreEqual()
        {
            var coordinates1 = new Coordinates(5.1, 10.5);
            var coordinates2 = new Coordinates(5.1, 10.5);

            Assert.Equal(coordinates1, coordinates2);
        }

        [Fact]
        public void CoordinatesWithSameLongitudeAndLatitude_ReturnSameHashCode()
        {
            var coordinates1 = new Coordinates(5.1, 10.5);
            var coordinates2 = new Coordinates(5.1, 10.5);

            Assert.Equal(coordinates1.GetHashCode(), coordinates2.GetHashCode());
        }
    }
}
