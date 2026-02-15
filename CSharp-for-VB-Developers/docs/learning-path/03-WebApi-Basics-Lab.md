# 03 - Web API Basics Lab

Primary project: `src/11-WebApi-CleanArchitecture`.

Goal: add endpoints, validation, and structured logging in a realistic but compact API.

## Lab setup

### Prerequisites

- Modules 01-02 complete.
- Terminal in `CSharp-for-VB-Developers/`.

### Start API

```bash
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

Swagger: `http://localhost:5111/swagger`

---

## Exercise 3.1 - Add `GET /api/version`

**Goal**
- Add a simple metadata endpoint returning version and UTC time.

**Steps**
1. Edit `src/11-WebApi-CleanArchitecture/Program.cs`.
2. Add mapping near other `app.MapGet` calls:

```csharp
app.MapGet("/api/version", () =>
{
    var version = typeof(Program).Assembly.GetName().Version?.ToString() ?? "unknown";
    return Results.Ok(new { version, serverTimeUtc = DateTime.UtcNow });
});
```

3. Build:

```bash
dotnet build src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

**Expected outcome**
- `/api/version` appears in Swagger and returns JSON with version/time.

**Verification**

```bash
curl "http://localhost:5111/api/version"
```

**Common pitfalls (VB6 gotchas)**
- Returning local time instead of UTC.
- Building strings manually instead of returning structured JSON object.

**Stretch goals**
- Include environment name in response (`builder.Environment.EnvironmentName`).

---

## Exercise 3.2 - Add POST endpoint with DTO validation

**Goal**
- Create an endpoint that accepts JSON DTO and validates input.

**Steps**
1. In `Program.cs`, add a DTO record near existing records:

```csharp
public record CreateNoteRequest(string Title, string Body);
```

2. Add endpoint:

```csharp
app.MapPost("/api/notes", (CreateNoteRequest request) =>
{
    var errors = new Dictionary<string, string[]>();

    if (string.IsNullOrWhiteSpace(request.Title))
        errors["title"] = ["Title is required."];

    if (string.IsNullOrWhiteSpace(request.Body))
        errors["body"] = ["Body is required."];

    if (errors.Count > 0)
        return Results.ValidationProblem(errors, title: "Validation failed");

    return Results.Ok(new { id = Guid.NewGuid(), request.Title, request.Body });
});
```

3. Run and test from Swagger.

**Expected outcome**
- Invalid payload returns 400 validation problem.
- Valid payload returns 200 with generated id.

**Verification**

```bash
curl -i -X POST "http://localhost:5111/api/notes" -H "Content-Type: application/json" -d '{"title":"","body":""}'
curl -i -X POST "http://localhost:5111/api/notes" -H "Content-Type: application/json" -d '{"title":"Hello","body":"From lab"}'
```

**Common pitfalls (VB6 gotchas)**
- Forgetting JSON property names are case-insensitive by default, but your returned keys should still be consistent.
- Assuming parameter binding from form/query automatically; for APIs, JSON body binding is typical.
- Skipping validation because "UI already validates".

**Stretch goals**
- Return `201 Created` with location header.

---

## Exercise 3.3 - Add structured logging

**Goal**
- Log endpoint actions with named properties.

**Steps**
1. Update `/api/notes` endpoint signature to include `ILoggerFactory loggerFactory`.
2. Add logger usage:

```csharp
var logger = loggerFactory.CreateLogger("Notes");
logger.LogInformation("Creating note with title {TitleLength} chars", request.Title.Length);
```

3. Log validation failures and success path.

**Expected outcome**
- Console logs show structured entries with named placeholders.

**Verification**

```bash
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

Then call endpoint and watch logs.

**Common pitfalls (VB6 gotchas)**
- Concatenating log strings instead of structured templates.
- Logging full secret or sensitive payloads.

**Stretch goals**
- Include correlation id (`HttpContext.TraceIdentifier`) in logs.

---

## Lab checklist

- [ ] `/api/version` implemented and verified
- [ ] `/api/notes` validation behavior verified
- [ ] Structured logs added and observed
