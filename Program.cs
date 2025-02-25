// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TelemetryFlow.Contracts;
using TelemetryFlow.Services;

namespace TelemetryFlow
{
    public class Program
    {

        public static async Task Main()
        {
            var logger = new LoggerConfiguration()
                    .WriteTo.File(string.Concat(Directory.GetCurrentDirectory(),
                    $"\\Logs\\Log{DateTime.Today.ToShortDateString().Replace("/", string.Empty)}.txt"))
                    .MinimumLevel.Information()
                    .CreateLogger();
            var serviceProvider = new ServiceCollection()
            .AddSingleton<ILogger>(logger)
            .AddSingleton<IMessageSender, IotHubMessageSender>()
            .AddSingleton<IDeviceSimulator, DeviceSimulator>()
            .AddSingleton<IStartupService, StartupService>()
            .BuildServiceProvider();

            var service = serviceProvider.GetService<IStartupService>();
            await service.StartService();

            Console.ReadLine();
        }
    }
}