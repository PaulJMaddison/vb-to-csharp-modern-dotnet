# Hosting Web APIs and Workers

This section helps VB6 teams choose practical hosting options during migration.

> **Why this matters:** Hosting choices affect deployment safety, operational overhead, and team learning curve.

## Hosting options overview

## 1) IIS hosting for ASP.NET Core APIs

Common for Windows-heavy teams and existing IIS operations.

- **In-process hosting**
  - ASP.NET Core runs inside IIS worker process.
  - Good performance and straightforward setup.
- **Out-of-process hosting**
  - IIS acts as reverse proxy to Kestrel process.
  - Useful for certain isolation/debug scenarios.

Best when your current ops model already uses IIS and Windows Server.

## 2) Windows Service for background workers

Use for long-running background tasks, queue polling, and scheduled domain work.

- Managed by Service Control Manager.
- Auto-start and restart options.
- Better operational model than ad-hoc scheduled scripts.

## 3) Containers (overview)

- Consistent runtime packaging.
- Good for Kubernetes or modern platform teams.
- Adds orchestration complexity if team is new to containers.

## 4) Cloud App Service (overview)

- Fast PaaS deployment path.
- Built-in scaling and diagnostics.
- Requires cloud governance and networking readiness.

## What we recommend first (for most VB6 migration teams)

1. **Web APIs on IIS** (lowest operational change).
2. **Workers as Windows Services** (replace fragile task scripts).
3. Introduce containers/cloud selectively after team confidence grows.

Reason: this sequence modernises delivery without forcing a full ops model shift on day one.

## Hosting a Worker as a Windows Service (concrete steps)

## 1) Add Windows Services hosting package

In worker project (`.csproj`), add:

```xml
<PackageReference Include="Microsoft.Extensions.Hosting.WindowsServices" Version="8.0.0" />
```

## 2) Configure the host

In `Program.cs`:

```csharp
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();

builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Modernisation.Worker.InvoiceSync";
});

var app = builder.Build();
app.Run();
```

## 3) Publish the worker

```bash
dotnet publish src/05-WorkerService/WorkerService.csproj -c Release -o C:\Services\InvoiceSyncWorker
```

## 4) Install service with `sc create`

```powershell
sc.exe create InvoiceSyncWorker binPath= "C:\Services\InvoiceSyncWorker\WorkerService.exe" start= auto
sc.exe description InvoiceSyncWorker "Processes invoice synchronization jobs"
```

## 5) Install service with PowerShell `New-Service` (alternative)

```powershell
New-Service -Name "InvoiceSyncWorker" `
  -BinaryPathName "C:\Services\InvoiceSyncWorker\WorkerService.exe" `
  -DisplayName "Invoice Sync Worker" `
  -StartupType Automatic
```

### Warnings

- Run install commands in elevated shell (Administrator).
- Use a dedicated least-privilege service account for production.
- Confirm service account permissions to DB/file shares.
- Configure recovery actions (restart on failure).

## Operational checklist for production readiness

- [ ] Health endpoints for APIs.
- [ ] Centralised logs with correlation IDs.
- [ ] Service restart policy documented.
- [ ] Deployment rollback steps tested.
- [ ] Secrets moved out of config files.

Read next: [05-Database-Migration-Strategy.md](./05-Database-Migration-Strategy.md).
