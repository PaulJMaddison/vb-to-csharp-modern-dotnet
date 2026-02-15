var builder = WebApplication.CreateBuilder(args);

// The gateway acts as the "front door" in strangler migrations.
// Clients call this app while requests are progressively routed to modernized services.
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.Use(async (context, next) =>
{
    const string headerName = "X-Correlation-ID";
    var correlationId = context.Request.Headers[headerName].FirstOrDefault();

    if (string.IsNullOrWhiteSpace(correlationId))
    {
        correlationId = Guid.NewGuid().ToString("N");
    }

    context.Items[headerName] = correlationId;
    context.Request.Headers[headerName] = correlationId;
    context.Response.Headers[headerName] = correlationId;

    using (app.Logger.BeginScope(new Dictionary<string, object?> { ["CorrelationId"] = correlationId }))
    {
        app.Logger.LogInformation(
            "Gateway request {Method} {Path} with correlation id {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        await next();
    }
});

app.MapGet("/", () =>
    "ReverseProxyGateway is running. Use /api/* for core APIs and /auth/* for authentication APIs.");

app.MapReverseProxy();

app.Run();
