# Release and Rollback Safety Patterns

Safe delivery is essential during strangler migration because legacy and modern modules coexist.

> **Why this matters:** You are not done when deployment succeeds. You are done when production behavior is stable and reversible.

## 1) Feature flags

Use feature flags to turn new behavior on/off without redeploying.

Recommended practices:

- Keep flag names business-readable (for example `Orders.NewValidation`).
- Define owner and expiry date for each flag.
- Remove stale flags after rollout completion.

Use flags to:

- Enable new module for internal users first.
- Switch between legacy and modern implementation for same feature.

## 2) Canary releases

Canary = release to a small traffic subset first.

Example progression:

1. Internal users only.
2. 5% external traffic.
3. 25% traffic.
4. 100% if stable.

At each step, compare:

- Error rates.
- Latency percentiles.
- Business outcomes (e.g., order completion rate).

## 3) Blue/green basics

Maintain two production environments:

- **Blue** (current live)
- **Green** (new release candidate)

Switch traffic from blue to green once validation passes.

Benefits:

- Fast rollback (switch back).
- Lower deployment downtime.

Costs:

- More infrastructure and release discipline.

## 4) Rollback plan (must exist before release)

Each release should define:

- Trigger conditions (what metrics cause rollback).
- Who decides rollback.
- How to rollback route/config/database changes.
- Post-rollback validation checks.

### Sample rollback template

```text
Release: Orders API v1.8
Rollback trigger: p95 latency > 2500 ms for 10 min OR error rate > 2%
Rollback action:
  1) Flip gateway route /orders/* to legacy
  2) Disable feature flag Orders.ModernPath
  3) Verify order create/read smoke tests
Owner on-call: Platform + Orders lead
```

## Logging/telemetry requirements

Minimum required before production cutover:

- Structured logs with correlation IDs.
- Request metrics: rate, errors, latency p50/p95/p99.
- Dependency metrics: DB calls, downstream API failures.
- Business KPI probes for migrated workflows.
- Dashboards + alerts reviewed by on-call team.

## Pre-release checklist

- [ ] Feature flag and fallback path tested.
- [ ] Canary stages defined.
- [ ] Rollback runbook approved.
- [ ] On-call coverage confirmed.
- [ ] Post-release observation window scheduled.

Read next: [07-12-to-24-Month-Roadmap.md](./07-12-to-24-Month-Roadmap.md).
