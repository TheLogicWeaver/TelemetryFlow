using Serilog;
using TelemetryFlow.Contracts;

namespace TelemetryFlow.Services
{
    internal class StartupService : IStartupService
    {
        private readonly ILogger _logger;
        private readonly IDeviceSimulator _deviceSimulator;

        public StartupService(ILogger logger, IDeviceSimulator deviceSimulator)
        {
            _logger = logger;
            _deviceSimulator = deviceSimulator;
        }

        public async Task StartService()
        {
            try
            {
                await _deviceSimulator.StartDeviceSimulatorAsync();
            }
            catch (Exception ex)
            {
                _logger.Error($"Service failed to start. Details: {ex.Message}");
            }
        }
    }
}