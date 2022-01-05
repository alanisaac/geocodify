using System;
using System.Threading.Tasks;
using Geodata.MapQuest;
using Xunit;

namespace Geodata.Tests.MapQuest
{
    [Collection("Settings")]
    public class MapQuestProviderTests
    {
        private readonly MapQuestProvider _provider;

        public MapQuestProviderTests(SettingsFixture settingsFixture)
        {
            var settings = settingsFixture.Settings;
            _provider = new MapQuestProvider(settings.MapQuestKey);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Constructor_ThrowsIfKeyIsNullOrWhitespace(string key)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new MapQuestProvider(key);
            });
        }

        [Theory]
        [InlineData("1060 W. Addison St., Chicago IL, 60613")]
        public async Task Geocode_CanGeocodeAddress(string address)
        {
            var response = await _provider.Geocode(new GeocodeRequest
            {
                Address = address
            });

            Assert.NotEmpty(response.Results);
        }
    }
}
