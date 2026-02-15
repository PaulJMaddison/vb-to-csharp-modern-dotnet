# Learning Path: VB6/VB Windows Developers to Modern C#/.NET 8

This learning path turns the sample projects in this repository into a repeatable training program.

Use it in three modes:

- **Self-study**: one developer moving module-by-module.
- **Team upskilling**: a small cohort doing 2-3 labs per week.
- **Trainer-led workshop**: instructor demos first, then participants complete exercises.

> VB6 mapping: think of this as a guided “upgrade plan” with checkpoints, not just a code dump.

## How to use this learning path

1. Start with [01-Getting-Set-Up](./01-Getting-Set-Up.md).
2. Follow labs in numeric order unless your trainer selects a custom track.
3. For each exercise, complete:
   - goal
   - prerequisites
   - explicit steps
   - expected outcome
   - verification
   - pitfalls
   - stretch goal
4. Track completion with checklists in each module.
5. Record notes in your branch/PR after each lab.

## Suggested timelines

### 1-week crash course (intensive)

- **Day 1**: 01 setup + 02 C# quick wins
- **Day 2**: 03 Web API basics
- **Day 3**: 04 auth + 05 integration testing
- **Day 4**: 06 gateway + 07 data access
- **Day 5**: 08 UI + 09 worker + capstone kickoff

Best for experienced developers with dedicated time.

### 4-week ramp-up (balanced)

- **Week 1**: 01 + 02 + selected 03 exercises
- **Week 2**: complete 03 + 04
- **Week 3**: 05 + 06 + 07
- **Week 4**: 08 + 09 + 10 capstone

Best for teams learning while delivering features.

### 8-week program (deep confidence)

- **Weeks 1-2**: foundation (01-03)
- **Weeks 3-4**: auth/testing (04-05)
- **Weeks 5-6**: architecture/data (06-07)
- **Week 7**: web UI and worker patterns (08-09)
- **Week 8**: capstone + code review + retrospective

Best for trainer-led internal academies.

## Run the lab locally (gateway + APIs + web apps)

From repository root (`CSharp-for-VB-Developers/`):

```bash
dotnet build CSharpForVBDevelopers.sln
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

Start core backend lab services:

- **Windows PowerShell**: `./scripts/run-all.ps1`
- **bash (Linux/macOS/WSL)**: `./scripts/run-all.sh`

Manual start (three terminals):

```bash
dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj
```

Useful URLs:

- Gateway: `http://localhost:5000`
- Auth API Swagger: `http://localhost:5222/swagger`
- Clean API Swagger: `http://localhost:5111/swagger`
- Gateway forwarded API sample: `http://localhost:5000/api/customers`

Optional web UI labs:

```bash
dotnet run --project src/03-WebApp-RazorPages/WebAppRazorPages.csproj
dotnet run --project src/07-MvcWebApp/MvcWebApp.csproj
dotnet run --project src/06-BlazorWebApp/BlazorWebApp.csproj
```

## Check progress

Use both:

- [EXERCISES-INDEX.md](./EXERCISES-INDEX.md) for planning.
- Checklist section inside each module.

Recommended completion rule:

- Mark exercise done only when **verification steps pass**.
- If blocked, note the blocker and move to next exercise.

## Questions and improvements

Suggested internal process:

1. Open an issue (or team ticket) with:
   - lab file name
   - exact step number
   - observed vs expected behavior
   - logs/screenshot/error output
2. Propose improvements via small PRs:
   - one lab tweak per PR when possible
   - include before/after wording and reason
3. Ask for review from:
   - one trainer/lead
   - one learner who recently used the lab

If your team does not use GitHub issues, use your internal tracker and link back to file paths.

## Module checklist

- [ ] 01 Getting Set Up
- [ ] 02 C# Quick Wins
- [ ] 03 Web API Basics Lab
- [ ] 04 Auth Lab
- [ ] 05 Integration Testing Lab
- [ ] 06 Gateway Strangler Lab
- [ ] 07 Data Access Lab
- [ ] 08 Web UI Lab
- [ ] 09 Worker/Background Jobs Lab
- [ ] 10 Capstone Project
