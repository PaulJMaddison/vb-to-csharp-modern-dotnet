namespace WebApiClean;

// Correlation IDs make log tracing easier across many services.
public sealed class CorrelationIdMiddleware(RequestDelegate next)
{
    private const string HeaderName = "X-Correlation-Id";

    public async Task Invoke(HttpContext context)
    {
        var incoming = context.Request.Headers[HeaderName].FirstOrDefault();
        context.TraceIdentifier = string.IsNullOrWhiteSpace(incoming)
            ? Guid.NewGuid().ToString("N")
            : incoming;

        context.Response.Headers[HeaderName] = context.TraceIdentifier;
        await next(context);
    }
}
