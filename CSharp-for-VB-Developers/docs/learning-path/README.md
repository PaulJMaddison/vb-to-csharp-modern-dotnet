# Learning Path: VB.NET (.NET Framework) to Modern C#/.NET

Use this folder as a practical track for teams moving from **VB.NET on .NET Framework 4.5+** to modern .NET 8 services and web applications.

## Positioning for this audience

This path assumes your team already has some MVC/Blazor exposure. Treat web UI labs as **reference + standards + refresher**, while spending most effort on:

- C# idioms and maintainable language patterns.
- DI, configuration, logging, and test automation baselines.
- Gateway/strangler migration slices.
- .NET Framework -> .NET upgrade sequencing.

## Suggested order

1. `01-Setup.md` and `01-Getting-Set-Up.md`
2. `02-CSharp-Quick-Wins.md`
3. `03-WebApi-Basics-Lab.md`
4. `04-Auth-Lab.md`
5. `05-Testing-Lab.md` + `05-Integration-Testing-Lab.md`
6. `06-Gateway-Strangler-Lab.md`
7. `07-Data-Access-Lab.md`
8. `08-Web-UI-Lab.md` (reference/refresher)
9. `09-Worker-Background-Jobs-Lab.md`
10. `10-Capstone-Project.md`

Useful references:

- Exercises index: [EXERCISES-INDEX.md](./EXERCISES-INDEX.md)
- Gateway pattern notes: [../patterns/reverse-proxy-gateway.md](../patterns/reverse-proxy-gateway.md)
- Testing notes: [../patterns/testing-unit-vs-integration.md](../patterns/testing-unit-vs-integration.md)
- Modernisation roadmap: [../modernisation/07-12-to-24-Month-Roadmap.md](../modernisation/07-12-to-24-Month-Roadmap.md)

## Run the lab stack (gateway + APIs)

From repo root (`CSharp-for-VB-Developers`):

### Option A: start all with scripts

- Windows PowerShell:

```powershell
./scripts/run-all.ps1
```

- Linux/macOS:

```bash
./scripts/run-all.sh
```

### Option B: run services manually

```bash
dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
dotnet run --project src/11-WebApi-CleanArchitecture/WebApiClean.csproj
dotnet run --project src/13-ReverseProxy-Gateway/ReverseProxyGateway.csproj
```

### Smoke-check endpoints

```bash
curl http://localhost:5222/swagger
curl http://localhost:5111/health
curl http://localhost:5000/api/customers
```
