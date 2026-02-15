# Discovery Checklist

Use this before writing modern code. The objective is to remove hidden coupling and release surprises.

## 1) Business process mapping

Capture each critical flow end-to-end:

- Entry point (screen/page/batch file/API).
- Users and timing (daily close, month-end, etc.).
- Inputs/outputs (files, DB rows, emails, reports).
- Failure impact (financial, compliance, operations).

### Output

- A ranked list of candidate migration slices by business value and risk.

## 2) Application and runtime inventory

Record the real estate, not the desired architecture:

- IIS sites/app pools and bindings.
- VB6 COM components and registrations.
- Scheduled Tasks / Windows Services / batch executables.
- External dependencies (SMTP, file shares, SOAP/REST, printers).

### Output

- Versioned inventory document with owners.

## 3) Database usage analysis

For each module, identify:

- Tables/views/stored procedures touched.
- Read vs write behavior.
- Transaction boundaries.
- Lock/contention hotspots.

### Output

- Data dependency matrix per module.

## 4) Operational baseline

Measure current behavior before migration:

- Request throughput and p95 latency.
- Error rates and retry rates.
- Batch duration and failure frequency.
- Deployment frequency and mean time to recover.

### Output

- Baseline metrics dashboard or spreadsheet.

## 5) Security and compliance review

Document:

- Authentication/authorization model.
- Secret storage approach.
- Audit requirements and retention.
- Network constraints (DMZ, firewall rules).

### Output

- Minimum security controls for new services.

## 6) Team readiness

Confirm:

- Who owns architecture decisions.
- On-call and support model.
- CI/CD ownership.
- Training needs (C#, ASP.NET Core, observability).

### Output

- Skill/risk heatmap and onboarding plan.

## Definition of “ready for first slice”

- [ ] Top 3 business-critical flows mapped.
- [ ] Current runtime inventory complete.
- [ ] DB dependency map for first slice complete.
- [ ] Baseline metrics captured.
- [ ] Rollback owner + process identified.

Next: [02-Strangler-Fig-Approach.md](./02-Strangler-Fig-Approach.md)
