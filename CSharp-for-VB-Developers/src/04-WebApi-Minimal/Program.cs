using System.Collections.Concurrent;

var builder = WebApplication.CreateBuilder(args);

// OpenAPI/Swagger is common for Web APIs (documentation + testing UI).
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

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
        return Results.BadRequest(new { error = "Title is required." });

    var newId = Interlocked.Increment(ref id);
    var item = new TodoItem(newId, request.Title.Trim(), false);
    todos[newId] = item;

    logger.LogInformation("Created todo {Id}: {Title}", item.Id, item.Title);

    return Results.Created($"/api/todos/{item.Id}", item);
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
