using Microsoft.Azure.Devices.Client;

namespace TelemetryFlow.Contracts
{
    public interface IDeviceClientWrapper
    {
        Task SendEventAsync(Message message);
    }
}