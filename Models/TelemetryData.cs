namespace TelemetryFlow.Models
{
    public class TelemetryData
    {
        public required string deviceId { get; set; }
        public double temperature { get; set; }
        public double humidity { get; set; }
        public DateTime timestamp { get; set; }
    }
}