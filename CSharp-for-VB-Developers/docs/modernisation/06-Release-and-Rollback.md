# Release and Rollback

Modernisation succeeds when deployment is safe and reversible.

## Release principles

- Small, frequent releases over large infrequent drops.
- One migration slice per release where possible.
- Predefined rollback path before approval to deploy.

## Recommended release flow

1. Build + automated tests.
2. Deploy to staging and run smoke/integration checks.
3. Validate dashboards (latency, errors, dependency health).
4. Production deploy with controlled exposure (feature flag/canary).
5. Monitor first 30-60 minutes with named release owner.

## Rollback strategies

## 1) Route rollback (preferred with gateway)

- Switch route back from new API to legacy endpoint.
- Fastest recovery when contracts are compatible.

## 2) App rollback

- Redeploy previous known-good artifact.
- Useful when route split is not available.

## 3) Data rollback

- Restore DB backup or execute vetted rollback script.
- Highest risk; use only when necessary and rehearsed.

## Minimum production checklist

- [ ] Feature flag or route toggle exists.
- [ ] Last known-good artifact available.
- [ ] Rollback owner and decision threshold defined.
- [ ] Dashboard/alerts prepared for release window.
- [ ] Post-release verification steps documented.

## Incident-trigger thresholds (example)

Rollback if any of these persist beyond agreed window:

- Error rate > 2x baseline.
- p95 latency > 50% regression.
- Failed business transaction spike.
- Worker backlog growth without recovery.

## Post-release review

After each release:

- Record what changed and why.
- Capture incidents and time-to-recover.
- Update runbooks/checklists based on findings.

Next: [07-12-to-24-Month-Roadmap.md](./07-12-to-24-Month-Roadmap.md)
