# C# for Visual Basic Windows App Developers

Small, runnable .NET 8 samples for experienced VB6/VB Windows developers learning practical modern C#.

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 (recommended) or VS Code
- Optional for database demos: Docker Desktop

## Quick start

```bash
dotnet build CSharpForVBDevelopers.sln
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

Run gateway + APIs together:

- Windows: `./scripts/run-all.ps1`
- Linux/Mac: `./scripts/run-all.sh`

## Local infrastructure (optional)

`docker-compose.yml` provides SQL Server for demos. Build/test does not require Docker.

```bash
docker compose up -d
```

SQL Server endpoint: `localhost,14333` (user: `sa`, password: `Your_password123`).

## Project catalog

### 01-WinFormsCSharp (`src/01-WinFormsCSharp`)
- **What**: Basic WinForms app in C#.
- **When to use**: Desktop line-of-business tools.
- **Run**: `dotnet run --project src/01-WinFormsCSharp/WinFormsCSharp.csproj` (Windows only)
- **Look for**: Event wiring, C# syntax differences from VB.

### 01-WinFormsVB (`src/01-WinFormsVB`)
- **What**: Minimal VB WinForms comparison app.
- **When to use**: Syntax side-by-side while migrating teams.
- **Run**: `dotnet run --project src/01-WinFormsVB/WinFormsVB.vbproj` (Windows only)
- **Look for**: Same concept implemented in VB vs C#.

### 02-ConsoleCSharp (`src/02-ConsoleCSharp`)
- **What**: Console basics and helper methods.
- **When to use**: Scripts, batch jobs, automation.
- **Run**: `dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj`
- **Look for**: Top-level statements, interpolation, method style.

### 03-WebApp-RazorPages (`src/03-WebApp-RazorPages`)
- **What**: ASP.NET Core Razor Pages app.
- **When to use**: Server-rendered internal web apps.
- **Run**: `dotnet run --project src/03-WebApp-RazorPages/WebAppRazorPages.csproj`
- **Look for**: PageModel handlers, request lifecycle.

### 04-WebApi-Minimal (`src/04-WebApi-Minimal`)
- **What**: Minimal API CRUD-style sample.
- **When to use**: Lightweight JSON services.
- **Run**: `dotnet run --project src/04-WebApi-Minimal/WebApiMinimal.csproj`
- **Look for**: Endpoint mapping, DI, logging basics.

### 05-WorkerService (`src/05-WorkerService`)
- **What**: Hosted background worker.
- **When to use**: Queue processing, polling, scheduled tasks.
- **Run**: `dotnet run --project src/05-WorkerService/WorkerService.csproj`
- **Look for**: `BackgroundService`, cancellation tokens, host logging.

### 06-BlazorWebApp (`src/06-BlazorWebApp`, planned)
- **What**: Planned Blazor sample.
- **When to use**: Interactive web UI with C#.
- **Run**: Not yet included.
- **Look for**: Component model and state handling (future).

### 07-MvcWebApp (`src/07-MvcWebApp`, planned)
- **What**: Planned ASP.NET Core MVC sample.
- **When to use**: Controller/view enterprise web apps.
- **Run**: Not yet included.
- **Look for**: Controllers, model binding, views (future).

### 08-WebApi-WithAuth (`src/08-WebApi-WithAuth`)
- **What**: JWT-secured Web API with public + protected endpoints.
- **When to use**: APIs consumed by SPAs/mobile/other services.
- **Run**: `dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj`
- **Look for**: Dev token endpoint (learning only), Swagger JWT authorize flow, token validation pipeline.

### 09-DataAccess-EFCore (`src/09-DataAccess-EFCore`)
- **What**: EF Core data access library (`DbContext`, entity, repository, service).
- **When to use**: Rich domain/data model with tracking and migrations.
- **Run**: Referenced by API projects; builds as class library.
- **Look for**: VB6 ADO comparison comments, unit-of-work with `SaveChanges`.

### 10-DataAccess-Dapper (`src/10-DataAccess-Dapper`)
- **What**: Dapper repository sample using explicit SQL.
- **When to use**: SQL-first, high-control data access.
- **Run**: Builds as class library.
- **Look for**: ADO vs Dapper vs EF Core tradeoff comments.

### 11-WebApi-CleanArchitecture (`src/11-WebApi-CleanArchitecture`)
- **What**: Small but realistic API using DTOs, validation, ProblemDetails, logging, correlation IDs.
- **When to use**: Team APIs needing consistent reliability patterns.
- **Run**: `dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj`
- **Look for**: Validation responses, middleware pipeline, structured logs.

### 12-IntegrationTests (`src/12-IntegrationTests`)
- **What**: xUnit integration tests using `WebApplicationFactory`.
- **When to use**: Verify endpoint behavior through full ASP.NET pipeline.
- **Run**: `dotnet test src/12-IntegrationTests/IntegrationTests.csproj`
- **Look for**: Stable tests without external DB dependencies.

### 13-ReverseProxy-Gateway (`src/13-ReverseProxy-Gateway`)
- **What**: YARP reverse proxy gateway.
- **When to use**: Front door routing and strangler-style modernization boundaries.
- **Run**: `dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj`
- **Look for**: Route forwarding `/api/*` and `/auth/*` to separate backend services.

## Pattern docs

See `docs/patterns/`:
- dependency-injection.md
- configuration-and-secrets.md
- logging-and-correlation.md
- error-handling-problemdetails.md
- data-access-ef-vs-dapper.md
- testing-unit-vs-integration.md
- reverse-proxy-gateway.md

## Tutorials

- [VB6 to C# and Modern .NET Tutorial](docs/tutorials/VB6-to-CSharp-Tutorial.md)
