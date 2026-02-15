using WebApiClean;
using DataAccessEfCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProblemDetails();

// InMemory keeps the sample/test stable and fast. Switch to SQL Server by changing DI registration.
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("WebApiCleanDb"));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<CustomerService>();

var app = builder.Build();

app.UseExceptionHandler();
app.UseStatusCodePages();
app.UseMiddleware<CorrelationIdMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/health", (HttpContext http) =>
{
    app.Logger.LogInformation("Health check hit. CorrelationId: {CorrelationId}", http.TraceIdentifier);
    return Results.Ok(new { Status = "ok", CorrelationId = http.TraceIdentifier });
});

app.MapGet("/api/customers", async (CustomerService service, CancellationToken ct) =>
{
    var customers = await service.GetCustomersAsync(ct);
    return Results.Ok(customers.Select(c => new CustomerDto(c.Id, c.Name, c.Email)));
});

app.MapPost("/api/customers", async (
    CreateCustomerRequest request,
    CustomerService service,
    HttpContext http,
    CancellationToken ct) =>
{
    var validationErrors = Validate(request);
    if (validationErrors.Count > 0)
    {
        return Results.ValidationProblem(validationErrors, statusCode: StatusCodes.Status400BadRequest,
            title: "Validation failed");
    }

    var customer = await service.CreateCustomerAsync(request.Name.Trim(), request.Email.Trim(), ct);
    http.RequestServices.GetRequiredService<ILoggerFactory>()
        .CreateLogger("CustomerEndpoints")
        .LogInformation("Customer created with id {CustomerId}", customer.Id);

    return Results.Created($"/api/customers/{customer.Id}", new CustomerDto(customer.Id, customer.Name, customer.Email));
});

app.Run();

static Dictionary<string, string[]> Validate(CreateCustomerRequest request)
{
    var errors = new Dictionary<string, string[]>();
    if (string.IsNullOrWhiteSpace(request.Name))
    {
        errors["name"] = ["Name is required."];
    }

    if (string.IsNullOrWhiteSpace(request.Email) || !request.Email.Contains('@'))
    {
        errors["email"] = ["Email must include @."];
    }

    return errors;
}

public record CustomerDto(int Id, string Name, string Email);
public record CreateCustomerRequest(string Name, string Email);

public partial class Program;
