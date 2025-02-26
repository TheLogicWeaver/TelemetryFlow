using TelemetryFlow.Models;

namespace TelemetryFlow.Utils
{
    internal class RandomTelemetryDataGenerator
    {
        private readonly Random _random = new Random();

        public TelemetryData GetTelemetryData(string deviceId)
        {
            return new TelemetryData
            {
                deviceId = deviceId,
                humidity = Math.Round(_random.NextDouble() * 100, 2),
                temperature = Math.Round(_random.NextDouble() * 40, 2),
                timestamp = DateTime.UtcNow
            };
        }
    }
}