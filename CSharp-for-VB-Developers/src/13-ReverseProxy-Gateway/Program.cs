var builder = WebApplication.CreateBuilder(args);

// Gateway = "front door" for clients. Useful as a strangler boundary while modernizing legacy apps.
builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapGet("/", () => "ReverseProxyGateway is running. Routes: /api/* and /auth/*");
app.MapReverseProxy();

app.Run();
