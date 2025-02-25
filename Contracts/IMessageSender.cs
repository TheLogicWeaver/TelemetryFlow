using TelemetryFlow.Models;

namespace TelemetryFlow.Contracts
{
    public interface IMessageSender
    {
        Task SendMessageAsync(TelemetryData data);
    }
}