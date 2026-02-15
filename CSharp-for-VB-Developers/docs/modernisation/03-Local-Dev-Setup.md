# Local Development Setup for Modernised Modules

This guide is for VB6 developers new to modern .NET CLI workflows.

> **Why this matters:** Fast, repeatable local setup reduces “works on my machine” problems and shortens onboarding.

## What you typically run locally

For strangler-style development, local environment often includes:

- Gateway (reverse proxy)
- One or more new Web APIs
- Optional local SQL Server in Docker
- Optional connection to shared dev services

## Recommended local run model

## Option A (simple): `dotnet run` for apps, Docker for DB only

Use this first. It is easiest to debug in IDE/terminal.

### 1) Start optional DB container

From repo root:

```bash
docker compose up -d
```

### 2) Start backend APIs in separate terminals

```bash
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
```

```bash
dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
```

### 3) Start gateway

```bash
dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj
```

### 4) Use helper script if preferred

- Windows: `./scripts/run-all.ps1`
- Linux/Mac: `./scripts/run-all.sh`

## Option B (later): containers for all services

Use only after team is comfortable. Container-first local setups can be great but add complexity early.

## Suggested local topology

```text
Browser/Postman
      |
      v
 localhost:5000 (Gateway)
   |                    |
   v                    v
:5100 WebApiClean   :5200 WebApiWithAuth
          \         /
           v       v
      SQL Server (Docker)
```

## Configuration tips

- Keep `appsettings.Development.json` for local settings.
- Never commit real secrets; use user secrets or environment variables.
- Document required env vars in a `.env.example` file.

## Troubleshooting for VB6 developers new to CLI

## Symptom: `dotnet` command not found

- Install .NET 8 SDK.
- Reopen terminal after install.
- Verify with `dotnet --info`.

## Symptom: Port already in use

- Change launch port in `Properties/launchSettings.json` for that project.
- Or stop conflicting process.

## Symptom: TLS certificate/browser warning

Run once:

```bash
dotnet dev-certs https --trust
```

## Symptom: SQL connection failures

- Confirm container is running: `docker ps`.
- Confirm connection string matches host/port.
- If using this repo’s compose defaults, SQL Server is on `localhost,14333`.

## Symptom: Gateway returns 502/Bad Gateway

- Check target APIs are running.
- Check gateway route config points to correct backend URLs.
- Inspect API startup logs for exceptions.

## Daily developer checklist

- [ ] Pull latest code.
- [ ] Start DB (if needed).
- [ ] Start API(s) and gateway.
- [ ] Hit health endpoint(s) before coding.
- [ ] Run relevant tests before commit.

Read next: [04-Hosting-WebApis.md](./04-Hosting-WebApis.md).
