# 03 - Web API Basics Lab

## Goal

Understand how modern ASP.NET Core APIs are structured and how to create/test endpoints without desktop UI coupling.

## Steps

1. Run minimal API sample:
   ```bash
   dotnet run --project src/04-WebApi-Minimal/WebApiMinimal.csproj
   ```
2. Open Swagger UI from console output URL.
3. Run clean architecture API:
   ```bash
   dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
   ```
4. Call a few endpoints with `curl` or Swagger and inspect status codes + payloads.
5. Review `Program.cs` and middleware order in each API.

## Verify

- You can successfully call at least one GET and one POST endpoint.
- You can explain dependency injection at a high level.
- You can describe why API contracts (DTOs/status codes) matter for clients.

## Common VB6 pitfalls

- Thinking request handling is equivalent to form button click flow.
- Returning ad-hoc strings instead of consistent JSON/problem responses.
- Embedding business/data logic directly in endpoint definitions.

## Stretch goals

- Add a simple validation rule and return a useful problem response.
- Introduce correlation ID logging and verify it in request logs.
