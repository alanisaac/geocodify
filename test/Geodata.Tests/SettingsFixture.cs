using Microsoft.Extensions.Configuration;

namespace Geodata.Tests
{
    public class SettingsFixture
    {
        public SettingsFixture()
        {
            Settings = new Settings();

            new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .AddJsonFile("settings.override.json", true)
                .Build()
                .Bind(Settings);
        }

        public Settings Settings { get; }
    }
}
