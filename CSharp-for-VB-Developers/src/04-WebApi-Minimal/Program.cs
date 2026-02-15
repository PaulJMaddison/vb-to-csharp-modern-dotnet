using System.Collections.Concurrent;
var builder = WebApplication.CreateBuilder(args);

// Built-in RFC7807 support (ProblemDetails / ValidationProblemDetails).
builder.Services.AddProblemDetails();

var app = builder.Build();

// Global exception handler returns a standard ProblemDetails payload.
app.UseExceptionHandler();

// Simple middleware so every request has a correlation id.
// - Reuses X-Correlation-ID if the caller already sent one.
// - Generates one otherwise.
// - Adds it to response headers and log scope.
app.Use(async (context, next) =>
{
    const string HeaderName = "X-Correlation-ID";
    var logger = context.RequestServices.GetRequiredService<ILoggerFactory>()
        .CreateLogger("Correlation");

    var correlationId = context.Request.Headers[HeaderName].FirstOrDefault();
    if (string.IsNullOrWhiteSpace(correlationId))
        correlationId = Guid.NewGuid().ToString("N");

    context.TraceIdentifier = correlationId;
    context.Response.Headers[HeaderName] = correlationId;

    using (logger.BeginScope(new Dictionary<string, object> { ["CorrelationId"] = correlationId }))
    {
        logger.LogInformation("Handling {Method} {Path} with correlation id {CorrelationId}",
            context.Request.Method,
            context.Request.Path,
            correlationId);

        await next();
    }
});


var todos = new ConcurrentDictionary<int, TodoItem>();
var id = 0;

// Minimal API: endpoints are functions mapped to routes.
// GET /api/todos
app.MapGet("/api/todos", () => todos.Values.OrderBy(t => t.Id));

// GET /api/todos/{id}
app.MapGet("/api/todos/{id:int}", (int id) =>
    todos.TryGetValue(id, out var todo)
        ? Results.Ok(todo)
        : Results.NotFound());

// POST /api/todos
app.MapPost("/api/todos", (CreateTodo request, ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("Todos");

    if (string.IsNullOrWhiteSpace(request.Title))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["title"] = ["Title is required."]
        });
    }

    var newId = Interlocked.Increment(ref id);
    var item = new TodoItem(newId, request.Title.Trim(), false);
    todos[newId] = item;

    logger.LogInformation("Created todo {Id}: {Title}", item.Id, item.Title);

    return Results.Created($"/api/todos/{item.Id}", item);
});

// GET /api/version
app.MapGet("/api/version", (HttpContext context) =>
{
    const string HeaderName = "X-Correlation-ID";

    return Results.Ok(new
    {
        AppName = app.Environment.ApplicationName,
        Version = typeof(Program).Assembly.GetName().Version?.ToString() ?? "unknown",
        UtcTime = DateTime.UtcNow,
        CorrelationId = context.Response.Headers[HeaderName].ToString()
    });
});

// PUT /api/todos/{id}
app.MapPut("/api/todos/{id:int}", (int id, UpdateTodo request) =>
{
    if (!todos.TryGetValue(id, out var existing))
        return Results.NotFound();

    var updated = existing with
    {
        Title = string.IsNullOrWhiteSpace(request.Title) ? existing.Title : request.Title.Trim(),
        IsDone = request.IsDone ?? existing.IsDone
    };

    todos[id] = updated;
    return Results.Ok(updated);
});

app.Run();

public record TodoItem(int Id, string Title, bool IsDone);
public record CreateTodo(string Title);
public record UpdateTodo(string? Title, bool? IsDone);
