# Database Migration Strategy and Tradeoffs

Database modernisation is often the highest-risk part of VB6 platform migration.

> **Why this matters:** Most migration outages are data consistency or schema-change issues, not controller code issues.

## Default recommendation: keep existing DB initially

For many teams, the safest path is:

- Keep existing SQL Server as primary data store.
- Modernise application layers first.
- Apply incremental, controlled schema evolution.

This avoids introducing app migration risk and database platform risk at the same time.

## Incremental schema changes with migrations

Use small, reversible schema updates tied to release cycles.

Examples:

- Add nullable columns before making them required.
- Add indexes before routing heavy read traffic.
- Introduce new tables for modern modules without breaking legacy queries.

## Strangler patterns at database layer

## 1) Views as compatibility layer

Create views that present legacy-shaped data while new schema evolves.

- Legacy code continues reading stable shape.
- New code can transition to new tables gradually.

## 2) Stored procedure boundary

Use stored procedures as stable contract during transition.

- Legacy and modern app paths call same procedures initially.
- Later, procedure internals evolve with schema changes.

## 3) Sidecar schema for new modules

Create new schema (for example `modern.*`) for migrated modules.

- Reduces collision with legacy naming and coupling.
- Enables cleaner ownership boundaries.

## Data sync vs single source of truth

Prefer **single source of truth** where possible.

### Single source of truth (recommended)

- One authoritative write path per business entity.
- Read models can be replicated/cached.
- Lower reconciliation complexity.

### Data sync/replication (use only when required)

- Needed for staged cutovers or reporting isolation.
- Requires explicit conflict handling and replay logic.
- Adds operational burden and monitoring needs.

## Tooling choices: EF Core migrations vs Flyway/DbUp vs manual SQL

## EF Core migrations

Good when app and schema are strongly coupled in .NET code.

Pros:

- Versioned with code.
- Easy developer workflow for .NET teams.

Cons:

- Less ideal for multi-app shared DB governance.

## Flyway or DbUp

Good when you want SQL-first migration control across teams.

Pros:

- Explicit SQL scripts and ordered execution.
- Easier for DBAs to review.

Cons:

- Requires disciplined script lifecycle and standards.

## Manual SQL change process

Can work in tightly controlled environments, but risky at scale.

Pros:

- Full control per change.

Cons:

- Prone to drift between environments.
- Harder auditability and repeatability unless process is strict.

## How to decide

Use these decision drivers:

- **Complexity:** number of interdependent modules and DB consumers.
- **Risk tolerance:** acceptable production impact if migration fails.
- **Downtime tolerance:** can you pause writes? for how long?
- **Governance model:** app-team owned DB vs central DBA-managed DB.

## What to avoid

1. **Dual writes without strategy**
   - Writing to two stores without idempotency and reconciliation leads to divergence.

2. **Large irreversible DDL changes in one release**
   - High rollback risk.

3. **Skipping backup/restore rehearsal**
   - Recovery becomes theoretical rather than operational.

## Release safety checklist for DB changes

- [ ] Migration scripts peer-reviewed.
- [ ] Tested against production-like data volume.
- [ ] Backward compatibility validated for legacy callers.
- [ ] Rollback path documented and rehearsed.
- [ ] Post-deploy verification queries prepared.

Read next: [06-Release-and-Rollback.md](./06-Release-and-Rollback.md).
