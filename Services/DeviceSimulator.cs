using System.Security.Cryptography;
using Serilog;
using TelemetryFlow.Contracts;
using TelemetryFlow.Utils;

namespace TelemetryFlow.Services
{
    internal class DeviceSimulator : IDeviceSimulator
    {
        private readonly ILogger _logger;
        private readonly IMessageSender _messageSender;
        private readonly RandomTelemetryDataGenerator _telemetryGenerator;

        public DeviceSimulator(ILogger logger, IMessageSender messageSender)
        {
            _logger = logger;
            _messageSender = messageSender;
            _telemetryGenerator = new RandomTelemetryDataGenerator();
        }

        public async Task StartDeviceSimulatorAsync()
        {
            try
            {
                while(true){
                    var data = _telemetryGenerator.GetTelemetryData("aniro-ssd001");
                    await _messageSender.SendMessageAsync(data);
                    await Task.Delay(500);
                }
            }
            catch (Exception ex)
            {                
                _logger.Error($"Failed to send data. Details: {ex.Message}");
            }
        }
    }
}