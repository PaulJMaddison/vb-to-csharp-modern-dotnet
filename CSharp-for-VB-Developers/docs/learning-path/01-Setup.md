# 01 - Setup Lab

## Goal

Get the local training environment running so every learner can build the solution, run at least one API, and call a health endpoint.

## Steps

1. Install prerequisites: .NET 8 SDK and IDE (Visual Studio 2022 or VS Code).
2. Restore/build solution:
   ```bash
   dotnet build CSharpForVBDevelopers.sln
   ```
3. Run the clean API:
   ```bash
   dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
   ```
4. In a second terminal, call:
   ```bash
   curl http://localhost:5111/health
   ```

## Verify

- Build succeeds with zero critical errors.
- API starts and logs listening URL.
- `curl` returns `200 OK` on `/health`.

## Common VB6 pitfalls

- Expecting “F5 in one EXE” behavior instead of multi-process service startup.
- Assuming machine-level COM registration patterns are required.
- Treating package restore errors as code errors (often SDK/tooling mismatch).

## Stretch goals

- Run `./scripts/run-all.sh` or `./scripts/run-all.ps1` to launch the full lab stack.
- Add a team setup checklist in your internal wiki.
