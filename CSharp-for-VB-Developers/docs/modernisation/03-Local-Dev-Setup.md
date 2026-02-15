# Local Dev Setup (Gateway + APIs + Optional Docker DB)

This setup is designed for developers moving from VB6 desktop/web environments to multi-service .NET development.

## Prerequisites

- .NET 8 SDK
- Visual Studio 2022 or VS Code + C# extension
- Optional: Docker Desktop (for local SQL Server)

## Services in this repo

- Gateway: `src/13-ReverseProxy-Gateway`
- Auth API: `src/08-WebApi-WithAuth`
- Clean API: `src/11-WebApi-CleanArchitecture`
- Worker: `src/05-WorkerService`

## Option A: quick start scripts

From repo root (`CSharp-for-VB-Developers`):

- Windows: `./scripts/run-all.ps1`
- Linux/macOS: `./scripts/run-all.sh`

This starts gateway + key APIs for day-to-day development.

## Option B: manual startup (multi-terminal)

Terminal 1:

```bash
dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
```

Terminal 2:

```bash
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

Terminal 3:

```bash
dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj
```

Optional Terminal 4 (worker):

```bash
dotnet run --project src/05-WorkerService/WorkerService.csproj
```

## Optional local database with Docker

Start SQL Server container:

```bash
docker compose up -d
```

Default endpoint from this repo:

- Host: `localhost,14333`
- User: `sa`
- Password: `Your_password123`

Stop/remove containers:

```bash
docker compose down
```

## Sanity checks

- Gateway route check: `http://localhost:5000/api/customers`
- Clean API health: `http://localhost:5111/health`
- Auth API swagger: `http://localhost:5222/swagger`

## Local debugging tips for VB6 developers

- Keep one terminal per service so logs remain readable.
- Use consistent correlation IDs when tracing across gateway + APIs.
- Start without Docker first; add DB container only when needed.
- Capture known-good startup order in team docs.

Next: [04-Hosting-WebApis-and-Workers.md](./04-Hosting-WebApis-and-Workers.md)
