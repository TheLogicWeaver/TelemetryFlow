using System.Configuration;
using System.Text;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Serilog;
using TelemetryFlow.Constants;
using TelemetryFlow.Contracts;
using TelemetryFlow.Models;

namespace TelemetryFlow.Services
{
    internal class IotHubMessageSender : IMessageSender
    {
        private readonly DeviceClient _deviceClient;
        private readonly string _connectionString = ProjectConstants.DevieConnectionString ?? string.Empty;
        private readonly ILogger _logger;

        public IotHubMessageSender(ILogger logger)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(_connectionString);
            _logger = logger;
        }

        public async Task SendMessageAsync(TelemetryData data)
        {
            string jsonMessage = JsonConvert.SerializeObject(data, Formatting.None);
            var message = new Message(Encoding.UTF8.GetBytes(jsonMessage));

            try
            {
                await _deviceClient.SendEventAsync(message);
                _logger.Information($"📡 Sent: {jsonMessage}");
            }
            catch (Exception ex)
            {
                _logger.Error($"❌ Error: {ex.Message}");
            }
        }
    }
}