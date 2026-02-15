# Learning Path: VB6/VB to Modern C#/.NET

Use this folder as a structured training track for teams moving from VB6 or older VB WinForms apps to modern .NET 8 services and web apps.

## How to use this repo for training

1. Start with setup and run at least one app + one API locally.
2. Work through each lab in order (01 → 06) and record outcomes in your team notes.
3. Keep each lab practical: run commands, validate endpoints, and discuss migration tradeoffs.
4. Use the exercise index to pick optional labs based on role (API dev, tester, platform engineer).

Useful references:

- Exercises index: [EXERCISES-INDEX.md](./EXERCISES-INDEX.md)
- Gateway pattern notes: [../patterns/reverse-proxy-gateway.md](../patterns/reverse-proxy-gateway.md)
- Testing notes: [../patterns/testing-unit-vs-integration.md](../patterns/testing-unit-vs-integration.md)

## Recommended schedules

### 1-week intensive (bootcamp style)

- **Day 1**: 01-Setup + 02-CSharp-Quick-Wins
- **Day 2**: 03-WebApi-Basics-Lab
- **Day 3**: 04-Auth-Lab
- **Day 4**: 05-Testing-Lab
- **Day 5**: 06-Gateway-Strangler-Lab + demo

Best for teams that can dedicate full-time learning hours.

### 4-week part-time plan

- **Week 1**: 01 + 02
- **Week 2**: 03
- **Week 3**: 04 + 05
- **Week 4**: 06 + modernization review

Best for delivery teams learning while continuing normal sprint work.

### 8-week gradual adoption plan

- **Weeks 1-2**: Setup, C# fundamentals, coding standards
- **Weeks 3-4**: Web API basics + first internal endpoint
- **Weeks 5-6**: Auth + test automation baseline
- **Weeks 7-8**: Gateway strangler slice and rollout checklist

Best for larger teams or environments with strict release controls.

## How to run the lab stack (gateway + APIs)

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

### Option B: run services manually (3 terminals)

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

If ports are occupied, stop old processes or update launch settings before continuing.
