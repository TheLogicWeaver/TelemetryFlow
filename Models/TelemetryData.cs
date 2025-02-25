namespace TelemetryFlow.Models
{
    public class TelemetryData
    {
        public required string DeviceId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime Timestamp { get; set; }
    }
}