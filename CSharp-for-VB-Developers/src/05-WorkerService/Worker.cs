using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService;

public sealed class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Cloud/back-end note:
        // BackgroundService is often used for queue processing, polling, scheduled work, etc.
        while (!stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }
}
