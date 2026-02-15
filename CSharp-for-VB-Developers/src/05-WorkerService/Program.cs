using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

// Register services for dependency injection.
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
