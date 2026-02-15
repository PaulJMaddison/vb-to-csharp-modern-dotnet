# Hosting Web APIs and Workers

This guide compares practical hosting options during VB.NET-to-.NET modernisation.

## Decision summary

## .NET Framework realities to account for

- Many older web apps depend on `System.Web` and IIS-integrated modules.
- Authentication/authorization hooks may be tied to IIS pipeline behavior.
- Some libraries remain Windows-only (COM, registry, Office automation, printer drivers).
- Plan to isolate these dependencies behind adapters before moving to cross-platform hosting.


For most Windows-centric teams:

1. Host ASP.NET Core APIs behind IIS.
2. Host background processing as Windows Services.
3. Introduce containers when operational maturity is ready.

## 1) IIS hosting for ASP.NET Core APIs

IIS is often the lowest-friction path for teams already operating Windows Server.

### Benefits

- Familiar operational model.
- Existing patching/certificate processes can be reused.
- Centralized app pool and site management.

### Tradeoffs

- Windows-only host dependency.
- Can delay cloud-native operating model learning.

### Typical use

- Internal line-of-business APIs with current IIS footprint.

## 2) Windows Service hosting for workers

Use Windows Services for long-running background jobs that replaced Scheduled Tasks or ad-hoc EXEs.

### Benefits

- Auto-start and recovery behavior.
- Standard service lifecycle management.
- Better reliability than script-driven scheduling.

### Tradeoffs

- Requires service account + permission hardening.
- Deployment needs service stop/start orchestration.

### Typical use

- Queue consumers, reconciliation jobs, file processing pipelines.

## 3) Containers (overview)

Container hosting can improve consistency across environments.

### Benefits

- Immutable deployment artifact.
- Easier horizontal scaling and platform portability.
- Strong fit for modern CI/CD workflows.

### Tradeoffs

- Requires container registry, scanning, and orchestration practices.
- Steeper learning curve for teams new to DevOps/Kubernetes.

### Typical use

- Teams with existing platform engineering support.

## Hosting matrix

| Workload | Fastest low-risk option | Scale-focused option |
|---|---|---|
| Web APIs | IIS + ASP.NET Core | Containers/App Service |
| Workers | Windows Service | Containers + job orchestrator |

## Operational minimums (any hosting model)

- [ ] Health/readiness endpoints.
- [ ] Structured logs with correlation IDs.
- [ ] Secret management outside source control.
- [ ] Deployment and rollback runbook.
- [ ] Alerts for error spike/latency regression.

Next: [05-Database-Migration-Strategy.md](./05-Database-Migration-Strategy.md)
