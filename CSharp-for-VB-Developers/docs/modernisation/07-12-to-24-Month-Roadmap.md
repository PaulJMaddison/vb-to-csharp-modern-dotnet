# 12–24 Month Modernisation Roadmap

This roadmap assumes an active legacy platform with ongoing business change requests.

> **Why this matters:** A staged roadmap helps you modernise safely while still delivering day-to-day business value.

## Stage 1 (Months 0–2): Discovery, baseline, first slice

### Objectives

- Complete discovery and risk mapping.
- Establish observability baseline.
- Deliver one production migration slice.

### Checklist

- [ ] Inventory complete (apps, COM, DB, integrations).
- [ ] Current-state architecture diagram approved.
- [ ] Gateway/routing boundary in place.
- [ ] First slice selected and scoped.
- [ ] First slice released with rollback tested.

### Definition of done

- First migrated module live in production.
- Metrics show no regression vs baseline for agreed KPIs.
- Team has documented runbook for release and rollback.

## Stage 2 (Months 3–6): Build repeatable factory pattern

### Objectives

- Standardise migration delivery process.
- Introduce CI/CD and quality gates.
- Standardise auth and cross-cutting patterns.

### Checklist

- [ ] Template for creating new migrated modules.
- [ ] CI pipeline with build + test + deploy stages.
- [ ] Central auth approach (JWT/cookies/identity provider) agreed.
- [ ] Logging/correlation standards applied to new services.
- [ ] At least 2–3 modules migrated using same pattern.

### Definition of done

- New module delivery is repeatable, not bespoke.
- Lead time for module releases is trending down.
- Auth and observability no longer vary by team.

## Stage 3 (Months 6–12): Scale migration, shrink legacy footprint

### Objectives

- Migrate multiple business-critical modules.
- Reduce dependency on legacy COM and fragile jobs.
- Improve operational reliability.

### Checklist

- [ ] 30–60% of target module set migrated (context dependent).
- [ ] Critical background jobs moved to managed worker services.
- [ ] Legacy-only DB objects identified for retirement.
- [ ] Incident trends improved (fewer Sev1/Sev2 for migrated paths).
- [ ] Support team trained on new runbooks.

### Definition of done

- Legacy system is no longer single point of failure for key workflows.
- Modern platform handles significant production traffic safely.
- Clear backlog exists for remaining high-risk modules.

## Stage 4 (Months 12–24): Decommission and harden

### Objectives

- Retire remaining legacy components in planned waves.
- Harden platform security, reliability, and governance.
- Optimise cost/performance.

### Checklist

- [ ] Decommission plan per legacy module approved by business owners.
- [ ] Legacy servers reduced/retired with audit trail.
- [ ] DR, backup, and recovery tested on modern stack.
- [ ] Security posture improved (patching, secrets, least privilege).
- [ ] Performance/cost review completed and actioned.

### Definition of done

- Target legacy footprint removed or isolated with explicit end-of-life timeline.
- Operational model is stable and supportable by current team.
- Modernisation transitions from project to normal engineering practice.

## Example timeline visual

```text
Months 0-2      3-6             6-12                    12-24
|---------------|---------------|-----------------------|------------------->
Discovery +     Factory         Scale module migration  Decommission +
first slice     pattern + CI/CD + reduce legacy risk    platform hardening
```

## Common roadmap risks and mitigations

- **Risk:** Underestimating legacy coupling.
  - **Mitigation:** Smaller slices, earlier dependency mapping, frequent retrospectives.

- **Risk:** Team split across old/new with no standards.
  - **Mitigation:** Shared templates, architecture reviews, pairing.

- **Risk:** No business alignment on sequencing.
  - **Mitigation:** Quarterly roadmap review with business and operations.
