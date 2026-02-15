# Ports and URLs Contract

This document defines the **default local endpoint contract** for all projects in this repository.
Use this as the source of truth for local development, scripts, and docs.

## Project Ports and URLs

| Project | Project folder | Default local port | Base URL | Swagger URL (if applicable) | Health URL | Notes |
|---|---|---:|---|---|---|---|
| 01-WinFormsCSharp | `src/01-WinFormsCSharp` | N/A | N/A | N/A | N/A | Windows-only desktop app. |
| 01-WinFormsVB | `src/01-WinFormsVB` | N/A | N/A | N/A | N/A | Windows-only desktop app (VB reference). |
| 02-ConsoleCSharp | `src/02-ConsoleCSharp` | N/A | N/A | N/A | N/A | Console app; no HTTP listener. |
| 03-WebApp-RazorPages | `src/03-WebApp-RazorPages` | `63761` (HTTP) | `http://localhost:63761` | N/A | N/A | HTTPS also available at `https://localhost:63760`. |
| 04-WebApi-Minimal | `src/04-WebApi-Minimal` | `63759` (HTTP) | `http://localhost:63759` | N/A | `http://localhost:63759/api/version` | HTTPS also available at `https://localhost:63758`. |
| 05-WorkerService | `src/05-WorkerService` | N/A | N/A | N/A | N/A | Background worker; no HTTP listener by default. |
| 06-BlazorWebApp | `src/06-BlazorWebApp` | `5260` (HTTP) | `http://localhost:5260` | N/A | N/A | Web UI app. HTTPS profile includes `https://localhost:7173`. |
| 07-MvcWebApp | `src/07-MvcWebApp` | `5121` (HTTP) | `http://localhost:5121` | N/A | N/A | Web UI app. HTTPS profile includes `https://localhost:7015`. |
| 08-WebApi-WithAuth | `src/08-WebApi-WithAuth` | `5222` | `http://localhost:5222` | `http://localhost:5222/swagger` | `http://localhost:5222/public/ping` | Protected endpoints require JWT token. |
| 09-DataAccess-EFCore | `src/09-DataAccess-EFCore` | N/A | N/A | N/A | N/A | Class library; consumed by API projects. |
| 10-DataAccess-Dapper | `src/10-DataAccess-Dapper` | N/A | N/A | N/A | N/A | Class library; consumed by API projects. |
| 11-WebApi-CleanArchitecture | `src/11-WebApi-CleanArchitecture` | `5111` | `http://localhost:5111` | `http://localhost:5111/swagger` | `http://localhost:5111/health` | Primary API behind gateway `/api/*`. |
| 12-IntegrationTests | `src/12-IntegrationTests` | N/A | N/A | N/A | N/A | Test project; no standalone HTTP endpoint. |
| 13-ReverseProxy-Gateway | `src/13-ReverseProxy-Gateway` | `5000` | `http://localhost:5000` | N/A | `http://localhost:5000/` | Gateway front door for `/api/*` and `/auth/*`. |

## Gateway Routing Map

Intended gateway route contract:

- `/api/*` -> Web API (default: `11-WebApi-CleanArchitecture`)
- `/auth/*` -> Auth API (`08-WebApi-WithAuth`)
- `/ui/*` -> Web UI (optional future route, not enabled by default)

ASCII routing diagram:

```text
Clients (browser, mobile, tools)
              |
              v
    http://localhost:5000  (ReverseProxy-Gateway)
          /        |        \
       /api/*    /auth/*    /ui/* (optional)
         |          |             |
         v          v             v
  http://localhost:5111   http://localhost:5222   Web UI app (if configured)
  (WebApi-Clean)          (WebApi-WithAuth)       (e.g., Razor/MVC/Blazor)
```

## How to override ports

You can override local binding URLs in two common ways.

### 1) `ASPNETCORE_URLS` environment variable

```bash
ASPNETCORE_URLS=http://localhost:5099 dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

PowerShell:

```powershell
$env:ASPNETCORE_URLS = "http://localhost:5099"
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

### 2) `dotnet run --urls ...`

```bash
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj --urls http://localhost:5099
```

> Tip: Prefer `--urls` for one-off runs and `ASPNETCORE_URLS` for shell/session-level defaults.
