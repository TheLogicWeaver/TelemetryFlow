using Microsoft.Azure.Devices.Client;
using TelemetryFlow.Constants;
using TelemetryFlow.Contracts;

namespace TelemetryFlow.Services
{
    public class DeviceClientWrapper : IDeviceClientWrapper
    {
        private readonly DeviceClient _deviceClient;
        private readonly string _connectionString = ProjectConstants.DeviceConnectionString ?? string.Empty;

        public DeviceClientWrapper()
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(_connectionString);
        }
        public async Task SendEventAsync(Message message)
        {
            await _deviceClient.SendEventAsync(message);
        }
    }
}