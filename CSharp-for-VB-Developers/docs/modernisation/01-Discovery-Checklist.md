# Discovery Checklist for VB6 Modernisation

Discovery is where most modernisation success is won or lost. Do this before committing to migration timelines.

> **Why this matters:** If you miss one scheduled job, one printer dependency, or one auth edge case, your first release can fail regardless of code quality.

## 1) System inventory checklist

Capture this in a spreadsheet or backlog with owner + criticality.

### Applications and modules

- [ ] Public web apps, internal web apps, admin portals.
- [ ] Module list (orders, invoicing, customer maintenance, reporting, etc.).
- [ ] Traffic estimates by module (daily users, peak times).
- [ ] Known pain points (timeouts, frequent defects, brittle pages).

### COM and legacy components

- [ ] COM DLL/EXE components and registration dependencies.
- [ ] COM+ packages and server-level configuration.
- [ ] Shared utility libraries used by multiple apps.
- [ ] 32-bit/64-bit assumptions.

### Database assets

- [ ] SQL Server instances, databases, and linked servers.
- [ ] Tables, views, stored procedures, SQL Agent jobs.
- [ ] Data ownership boundaries (which app owns which tables).
- [ ] Backup/restore process and current RPO/RTO expectations.

### Integrations

- [ ] File shares, FTP/SFTP, SMTP, printer servers.
- [ ] External APIs and authentication methods.
- [ ] Batch imports/exports and fixed file formats.
- [ ] Partner dependencies and SLA constraints.

## 2) Risk checklist

Focus on areas that break quietly.

- [ ] **Authentication/authorisation:** AD groups, custom cookies, hard-coded role checks.
- [ ] **Batch jobs:** nightly jobs, month-end processing, retry behavior.
- [ ] **Scheduled tasks:** Windows Task Scheduler scripts and credentials.
- [ ] **Printing:** direct printer calls, spooler assumptions, layout dependencies.
- [ ] **File shares:** UNC paths, network permissions, locked files.
- [ ] **Time-sensitive logic:** timezone, daylight saving, business calendar cutoffs.

## 3) Observability baseline plan

Before first migration slice, measure what “normal” looks like.

### Minimum telemetry for each critical module

- [ ] Request count (throughput).
- [ ] Error rate (4xx/5xx or functional failure count).
- [ ] Latency (p50/p95/p99).
- [ ] Dependency failures (DB timeout, external service timeout).

### Practical baseline process

1. Identify top 3 business-critical workflows.
2. Capture 2–4 weeks of baseline metrics.
3. Define alert thresholds from real baseline (not guesswork).
4. Store dashboard links in runbook documentation.

### Example baseline table

| Workflow | Current Error Rate | Current p95 Latency | Owner | Migration Target |
|---|---:|---:|---|---|
| Create order | 1.8% | 2200 ms | Sales platform | <1.0%, <1500 ms |
| Invoice run | 0.7% | 6 min batch | Finance ops | <0.5%, <4 min |
| Customer search | 2.5% | 3500 ms | Support app | <1.2%, <1800 ms |

## 4) Discovery outputs (definition of ready)

Do not start migration implementation until you have:

- [ ] Current architecture diagram.
- [ ] Prioritised module list with business value and risk.
- [ ] First migration slice selected and scoped.
- [ ] Observability baseline and owners assigned.
- [ ] Rollback assumptions documented for first release.

Read next: [02-Strangler-Fig-Approach.md](./02-Strangler-Fig-Approach.md).
