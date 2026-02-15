# 12-to-24 Month Modernisation Roadmap

This roadmap gives VB6 teams a practical sequencing model. Adjust timings to team size and risk tolerance.

## Months 0-3: foundation and first slice

- Complete discovery and runtime inventory.
- Introduce gateway with pass-through routing.
- Stand up CI/CD, logging, health checks.
- Deliver first low-risk vertical slice.

### Exit criteria

- First production slice live.
- Rollback tested.
- Baseline metrics established.

## Months 4-6: repeatable slice delivery

- Migrate 2-4 additional bounded slices.
- Standardize API templates, logging, and test patterns.
- Replace highest-risk scheduled/batch job with worker service.

### Exit criteria

- Predictable release cadence (e.g., bi-weekly).
- Reduced incidents for migrated areas.

## Months 7-12: scale migration and harden ops

- Expand strangler routing to core user journeys.
- Improve SLOs, alerting, and on-call readiness.
- Begin selective DB improvements where low risk.
- Decommission first legacy components.

### Exit criteria

- 30-50% of target workflows modernized.
- Operational runbooks in regular use.

## Months 13-18: optimize and retire major legacy areas

- Migrate high-complexity modules.
- Reduce shared DB coupling between old/new domains.
- Consolidate deployment pipelines.
- Retire redundant IIS/VB6 components.

### Exit criteria

- Majority of business-critical flows on modern stack.
- Legacy runtime footprint meaningfully reduced.

## Months 19-24: platform simplification and future state

- Complete remaining migrations or ring-fence residual legacy.
- Decide long-term hosting model (IIS-first, hybrid, or containers).
- Finish data model modernization backlog.
- Formalize architecture governance and skill transition plan.

### Exit criteria

- Stable modern platform with measurable delivery improvements.
- Legacy risk reduced to accepted residual set.

## KPI suggestions across roadmap

- Deployment frequency.
- Change failure rate.
- Mean time to recover.
- p95 latency for key journeys.
- Incident count per migrated module.

End of playbook. Return to [00-Modernisation-Overview.md](./00-Modernisation-Overview.md).
