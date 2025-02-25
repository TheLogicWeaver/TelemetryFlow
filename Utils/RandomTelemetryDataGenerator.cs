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
                DeviceId = deviceId,
                Humidity = Math.Round(_random.NextDouble() * 100, 2),
                Temperature = Math.Round(_random.NextDouble() * 40, 2),
                Timestamp = DateTime.UtcNow
            };
        }
    }
}