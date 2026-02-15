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

## Project Catalog

This solution intentionally mixes app styles so VB developers can compare old and new approaches side by side.

> **Visual Studio run pattern (applies to runnable apps):** Right-click the project in Solution Explorer → **Set as Startup Project** → press **F5**.

### 01-WinFormsCSharp (`src/01-WinFormsCSharp`)
- **What it is**: A C# WinForms desktop app.
- **When you'd use it**: You are modernizing an existing VB WinForms workflow and want minimum UI paradigm change.
- **How to run it**:
  - **VS**: Set `01-WinFormsCSharp` as startup project and run (Windows).
  - **CLI**: `dotnet run --project src/01-WinFormsCSharp/WinFormsCSharp.csproj` (Windows only).
- **What to look for (learning goals)**: Event handlers, partial classes, `Program.cs` startup, and C# language differences from VB.

### 01-WinFormsVB (`src/01-WinFormsVB`)
- **What it is**: A VB WinForms reference project for side-by-side comparison.
- **When you'd use it**: Your team is bilingual (VB + C#) and needs a migration bridge.
- **How to run it**:
  - **VS**: Set `01-WinFormsVB` as startup project and run (Windows).
  - **CLI**: `dotnet run --project src/01-WinFormsVB/WinFormsVB.vbproj` (Windows only).
- **What to look for (learning goals)**: 1:1 mental mapping between VB and C# patterns for forms/events.

### 02-ConsoleCSharp (`src/02-ConsoleCSharp`)
- **What it is**: A .NET console app with core C# syntax patterns.
- **When you'd use it**: Automation, scripts, data transforms, batch utilities.
- **How to run it**:
  - **VS**: Set `02-ConsoleCSharp` as startup project and run.
  - **CLI**: `dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj`.
- **What to look for (learning goals)**: Top-level statements, string interpolation, method syntax, and modern null-safe coding habits.

### 03-WebApp-RazorPages (`src/03-WebApp-RazorPages`)
- **What it is**: Server-rendered web UI using Razor Pages.
- **When you'd use it**: Internal business CRUD-style web app where page-centric development feels closest to forms thinking.
- **How to run it**:
  - **VS**: Set `03-WebApp-RazorPages` as startup project and run.
  - **CLI**: `dotnet run --project src/03-WebApp-RazorPages/WebAppRazorPages.csproj`.
- **What to look for (learning goals)**: `PageModel`, handler methods (`OnGet`, `OnPost`), model binding, validation, and request/response lifecycle.

### 04-WebApi-Minimal (`src/04-WebApi-Minimal`)
- **What it is**: Minimal API sample for HTTP JSON endpoints.
- **When you'd use it**: Lightweight services for internal integrations, SPA/mobile backends, or microservice endpoints.
- **How to run it**:
  - **VS**: Set `04-WebApi-Minimal` as startup project and run.
  - **CLI**: `dotnet run --project src/04-WebApi-Minimal/WebApiMinimal.csproj`.
- **What to look for (learning goals)**: Route mapping, dependency injection, request delegates, and OpenAPI/Swagger basics.

### 05-WorkerService (`src/05-WorkerService`)
- **What it is**: Background hosted service app (no UI).
- **When you'd use it**: Scheduled work, queue polling, file processing, integration jobs.
- **How to run it**:
  - **VS**: Set `05-WorkerService` as startup project and run.
  - **CLI**: `dotnet run --project src/05-WorkerService/WorkerService.csproj`.
- **What to look for (learning goals)**: `BackgroundService`, cancellation tokens, logging, and long-running process lifecycle.

### 06-BlazorWebApp (`src/06-BlazorWebApp`)
- **What it is**: Blazor web app using C# components for UI.
- **When you'd use it**: You want interactive web UI while staying mostly in C# instead of heavy JavaScript.
- **How to run it**:
  - **VS**: Set `06-BlazorWebApp` as startup project and run.
  - **CLI**: `dotnet run --project src/06-BlazorWebApp/BlazorWebApp.csproj`.
- **What to look for (learning goals)**: Razor components, component parameters, event callbacks, state-driven rendering, and component composition.

### 08-WebApi-WithAuth (`src/08-WebApi-WithAuth`)
- **What it is**: JWT-protected API with public and secured endpoints.
- **When you'd use it**: Any API that needs identity/authentication for browser, mobile, or service clients.
- **How to run it**:
  - **VS**: Set `08-WebApi-WithAuth` as startup project and run.
  - **CLI**: `dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj`.
- **What to look for (learning goals)**: Token issuance flow (demo), auth middleware pipeline, Swagger authorize flow, and claims-based authorization.

### 09-DataAccess-EFCore (`src/09-DataAccess-EFCore`)
- **What it is**: Class library showing EF Core patterns (`DbContext`, entities, repositories/services).
- **When you'd use it**: Domain-rich apps where change tracking, relationships, and migrations help productivity.
- **How to run it**:
  - **VS**: Build project or consume via dependent API project.
  - **CLI**: `dotnet build src/09-DataAccess-EFCore/DataAccessEfCore.csproj`.
- **What to look for (learning goals)**: Unit-of-work mental model (`SaveChanges`), query composition, and how EF replaces many hand-written ADO blocks.

### 10-DataAccess-Dapper (`src/10-DataAccess-Dapper`)
- **What it is**: Class library showing Dapper with explicit SQL.
- **When you'd use it**: SQL-first teams that want tight control and predictable query shape.
- **How to run it**:
  - **VS**: Build project or consume via dependent API project.
  - **CLI**: `dotnet build src/10-DataAccess-Dapper/DataAccessDapper.csproj`.
- **What to look for (learning goals)**: Explicit SQL mapping, parameterization, and tradeoffs vs EF Core.

### 11-WebApi-CleanArchitecture (`src/11-WebApi-CleanArchitecture`)
- **What it is**: Structured API sample with DTOs, validation, middleware, ProblemDetails, and observability patterns.
- **When you'd use it**: Team-owned APIs where consistency, supportability, and maintainability matter.
- **How to run it**:
  - **VS**: Set `11-WebApi-CleanArchitecture` as startup project and run.
  - **CLI**: `dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj`.
- **What to look for (learning goals)**: Layered boundaries, validation responses, correlation IDs, and production-friendly API behavior.

### 12-IntegrationTests (`src/12-IntegrationTests`)
- **What it is**: xUnit integration tests using in-memory app hosting (`WebApplicationFactory`).
- **When you'd use it**: You want confidence that real HTTP behavior works end-to-end before shipping.
- **How to run it**:
  - **VS**: Use **Test Explorer** and run test suite.
  - **CLI**: `dotnet test src/12-IntegrationTests/IntegrationTests.csproj`.
- **What to look for (learning goals)**: Full pipeline tests (routing, middleware, serialization) without brittle external dependencies.

### 13-ReverseProxy-Gateway (`src/13-ReverseProxy-Gateway`)
- **What it is**: YARP reverse proxy/gateway in front of downstream services.
- **When you'd use it**: API front door, route consolidation, and strangler migration from legacy systems.
- **How to run it**:
  - **VS**: Set `13-ReverseProxy-Gateway` as startup project and run.
  - **CLI**: `dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj`.
- **What to look for (learning goals)**: Route forwarding rules, backend decoupling, and evolution from monolith to service boundaries.

## Which UI should I choose?

### WinForms / WPF (desktop)
- **Best when**: You need rich local desktop behavior, device access, or offline-heavy usage.
- **WinForms**: Fastest transition for VB6/VB WinForms developers.
- **WPF**: Better long-term UI architecture (MVVM, binding, templating), but steeper learning curve.
- **Tradeoff**: Desktop deployment/updates are your responsibility unless you add enterprise deployment tooling.

### Razor Pages (web)
- **Best when**: You think in pages/forms and want straightforward server-rendered web apps.
- **Why VB devs like it**: Very direct mental model from event-driven form submissions.
- **Tradeoff**: Not as component-driven for highly interactive UX as Blazor.

### MVC (web)
- **Best when**: You need explicit separation (Controller + View + Model) and larger team conventions.
- **Why choose it**: Mature pattern for complex web apps and existing enterprise standards.
- **Tradeoff**: More moving parts than Razor Pages; heavier upfront structure.

### Blazor (web)
- **Best when**: You want rich, interactive UI and prefer writing C# across client + server.
- **Why choose it**: Reusable component model and shared .NET skills.
- **Tradeoff**: Requires learning component lifecycle/state patterns and (depending on hosting model) runtime/network considerations.

## Suggested learning path (for VB developers)

1. **Start with desktop familiarity**: `01-WinFormsVB` and `01-WinFormsCSharp`.
2. **Build C# fluency quickly**: `02-ConsoleCSharp`.
3. **Move to server-rendered web**: `03-WebApp-RazorPages`.
4. **Learn service layer fundamentals**: `04-WebApi-Minimal`.
5. **Add production patterns**: `11-WebApi-CleanArchitecture` + `12-IntegrationTests`.
6. **Learn auth/security basics**: `08-WebApi-WithAuth`.
7. **Study data access choices**: `09-DataAccess-EFCore` vs `10-DataAccess-Dapper`.
8. **Understand background processing**: `05-WorkerService`.
9. **Adopt modern interactive web UI**: `06-BlazorWebApp` (then MVC concepts from docs for structured controller/view teams).
10. **Plan modernization boundaries**: `13-ReverseProxy-Gateway` and strangler routing.

## Foundations

- [Windows vs Web Development](docs/foundations/Windows-vs-Web-Development.md)

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
## Modernisation Playbook

For teams modernising VB6/Classic ASP systems incrementally, see `docs/modernisation/`:

1. [00-Modernisation-Overview](docs/modernisation/00-Modernisation-Overview.md)
2. [01-Discovery-Checklist](docs/modernisation/01-Discovery-Checklist.md)
3. [02-Strangler-Fig-Approach](docs/modernisation/02-Strangler-Fig-Approach.md)
4. [03-Local-Dev-Setup](docs/modernisation/03-Local-Dev-Setup.md)
5. [04-Hosting-WebApis](docs/modernisation/04-Hosting-WebApis.md)
6. [05-Database-Migration-Strategy](docs/modernisation/05-Database-Migration-Strategy.md)
7. [06-Release-and-Rollback](docs/modernisation/06-Release-and-Rollback.md)
8. [07-12-to-24-Month-Roadmap](docs/modernisation/07-12-to-24-Month-Roadmap.md)

Suggested reading order is the numbered order above: start with discovery and strangler strategy, then implementation/hosting/data, then rollout and roadmap.
Also see:
- `docs/App-Types-Overview.md`
- `docs/VB-to-CSharp-Cheatsheet.md`
