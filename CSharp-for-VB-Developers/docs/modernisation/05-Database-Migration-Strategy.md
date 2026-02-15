# Database Migration Strategy

For VB6 modernisation, safest default is:

1. Keep the existing SQL Server schema first.
2. Migrate application/service layers incrementally.
3. Perform schema modernization in later phases.

## Why keep the DB first

- Reduces concurrent change risk (app + schema together is high risk).
- Preserves known reporting and integration behavior.
- Allows direct output comparison between legacy and modern endpoints.

## Phase model

## Phase 1: shared database, new app layer

- Legacy and modern services use the same DB.
- New APIs read/write through controlled repositories.
- Stored procedures can remain during transition.

## Phase 2: stabilize contracts and ownership

- Define explicit domain/service ownership.
- Reduce cross-module table coupling.
- Add migration-safe tests around critical SQL behavior.

## Phase 3: selective schema modernization

- Introduce additive schema changes first (new columns/tables).
- Decompose oversized stored procedures where justified.
- Implement migrations/versioning with rollback scripts.

## Tradeoffs: keep DB now vs migrate DB now

| Choice | Benefits | Risks |
|---|---|---|
| Keep DB first | Lower initial risk, faster first releases, easier parity checks | Carries legacy schema complexity longer |
| Migrate DB early | Can clean data model sooner | High blast radius, integration break risk, longer lead time |

## Practical safeguards

- Version SQL scripts in source control.
- Use backward-compatible schema changes first.
- Add canary checks for critical queries.
- Benchmark top 10 slow queries before/after each release.
- Keep a tested restore/rollback procedure for DB changes.

## When to modernize schema aggressively

Consider earlier DB modernization only if:

- Current schema blocks core product roadmap.
- Performance issues cannot be solved at app/query layer.
- Compliance/security requirements mandate data model changes.

Next: [06-Release-and-Rollback.md](./06-Release-and-Rollback.md)
