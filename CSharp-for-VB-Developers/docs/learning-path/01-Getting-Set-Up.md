# 01 - Getting Set Up

Goal: verify your machine can build and run the training solution from both Visual Studio 2022 and `dotnet` CLI.

## Prerequisites

- Visual Studio 2022 (17.8+ recommended) with workloads:
  - **ASP.NET and web development**
  - **.NET desktop development** (for WinForms projects)
- .NET 8 SDK (`dotnet --version` should return 8.x)
- Git

Optional:

- Docker Desktop (only for optional DB labs)

## First run checklist

- [ ] Clone repo
- [ ] Build solution
- [ ] Run Console app
- [ ] Run minimal Web API
- [ ] Open Swagger

## Step-by-step (CLI)

1. Open terminal in `CSharp-for-VB-Developers/`.
2. Build:

```bash
dotnet build CSharpForVBDevelopers.sln
```

3. Run console sample:

```bash
dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj
```

4. Run minimal API:

```bash
dotnet run --project src/04-WebApi-Minimal/WebApiMinimal.csproj
```

5. Open Swagger (look for URL from terminal), usually:

- `https://localhost:63758/swagger`
- `http://localhost:63759/swagger`

## Step-by-step (Visual Studio 2022)

1. Open `CSharpForVBDevelopers.sln`.
2. Restore/build solution (`Build > Build Solution`).
3. In Solution Explorer:
   - set `src/02-ConsoleCSharp` as startup project and run.
   - then set `src/04-WebApi-Minimal` as startup project and run.
4. Confirm browser opens Swagger.

## Project structure and layout

- `src/01-*` to `src/13-*`: runnable apps/libraries by topic.
- `src/12-IntegrationTests`: xUnit integration tests.
- `docs/patterns`: concept guides (DI, logging, gateway, etc.).
- `docs/learning-path`: guided labs (this curriculum).
- `scripts/run-all.*`: starts main APIs + gateway for multi-service labs.

VB6 mapping:

- `*.sln` is your “workspace shell” (like a group project).
- each `*.csproj` is a deployable unit/library (roughly like separate VB projects/components).

## Expected outcome

- Solution builds successfully.
- Console app prints output and exits.
- Web API starts and Swagger UI loads.

## Verification steps

1. Run:

```bash
dotnet --info
```

2. Confirm `.NET SDKs installed` includes 8.x.
3. Confirm `dotnet build` returns `Build succeeded`.
4. Confirm Swagger page loads and endpoints are visible.

## Troubleshooting

## Ports already in use

- Error like `Address already in use` means a conflicting process is using the same port.
- Change `applicationUrl` in `src/*/Properties/launchSettings.json` or stop conflicting process.

## HTTPS certificate issues

Run:

```bash
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

Then restart the app.

## Firewall prompts (Windows)

- Allow local dev access when prompted.
- If blocked, retry after allowing `dotnet`.

## Browser does not open Swagger

- Copy the URL printed in terminal and paste manually.
- Ensure app started in `Development` environment.

## Common pitfalls (VB6 mindset gotchas)

- Expecting one EXE to contain everything: modern apps are intentionally split by concern.
- Expecting UI app startup model for APIs: web hosts run continuously and listen on ports.
- Editing code without restore/build: package restore is first-class in .NET.

## Stretch goals (optional)

- Run integration tests:

```bash
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

- Run both API projects and gateway together via script.
