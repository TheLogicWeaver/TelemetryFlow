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
        private readonly ILogger _logger;
        private readonly IDeviceClientWrapper _deviceClientWrapper;

        public IotHubMessageSender(ILogger logger, IDeviceClientWrapper deviceClientWrapper)
        {
            _logger = logger;
            _deviceClientWrapper = deviceClientWrapper;
        }

        public async Task SendMessageAsync(TelemetryData data)
        {
            string jsonMessage = JsonConvert.SerializeObject(data, Formatting.None);
            var message = new Message(Encoding.UTF8.GetBytes(jsonMessage));

            try
            {
                if(message.GetBytes().Length == 0){
                    _logger.Error("Message is empty!");
                }
                await _deviceClientWrapper.SendEventAsync(message);
                _logger.Information($"📡 Sent: {jsonMessage}");
            }
            catch (Exception ex)
            {
                _logger.Error($"❌ Error: {ex.Message}");
            }
        }
    }
}