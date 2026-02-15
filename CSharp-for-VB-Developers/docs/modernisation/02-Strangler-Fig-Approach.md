# Strangler Fig Approach (Detailed)

The strangler fig approach modernises legacy systems incrementally by placing a routing layer in front of old and new implementations, then moving capabilities slice-by-slice.

## Why VB.NET teams benefit

- Preserves production stability while modernising.
- Avoids long periods without user-visible delivery.
- Creates rollback options at route/module level.
- Helps teams learn .NET and DevOps progressively.

## Core pattern

```text
               +----------------------+
Request -----> | Gateway / Proxy      |
               | (routing decisions)  |
               +----+------------+----+
                    |            |
           legacy route     modern route
                    |            |
                    v            v
              +-----------+  +----------------+
              | VB.NET/ASP   |  | ASP.NET Core   |
              | existing  |  | API/Worker     |
              +-----------+  +----------------+
```

The gateway becomes the seam where you control migration pace.

## Migration phases

## Phase 0 - Observe only

- Introduce gateway with pass-through routing.
- Add request IDs and basic latency/error logging.
- Do not change business behavior.

```text
Client -> Gateway(pass-through) -> Legacy only
```

## Phase 1 - First vertical slice

Select one bounded capability (example: customer search).

- Build modern endpoint in ASP.NET Core.
- Keep same contract shape where possible.
- Route only a narrow path to the new service.

```text
/legacy/*   -> Legacy IIS
/api/customers/search -> New API
```

## Phase 2 - Side-by-side verification

- Shadow traffic or replay representative requests.
- Compare output, timing, and error behavior.
- Fix semantic mismatches before broad rollout.

```text
                    +--> Legacy (baseline)
Gateway (sample %) -|
                    +--> New API (candidate)

Compare: status, payload, key fields, latency
```

## Phase 3 - Controlled expansion

- Move adjacent routes of same bounded context.
- Add feature flags for fast switchback.
- Keep DB schema stable while app logic migrates.

## Phase 4 - Legacy retirement

- Route all traffic for migrated context to modern service.
- Remove dead legacy endpoints/components.
- Archive runbooks and release notes.

## How to pick the first slice

Prefer modules that are:

- High value (frequent user pain or revenue impact).
- Medium complexity (not deepest legacy coupling first).
- Independently releasable.
- Observable (easy to measure success/failure).

Avoid picking cross-cutting foundational modules first.

## Suggested routing model

```text
                    +---------------------------+
                    |  Reverse Proxy Gateway    |
                    |---------------------------|
Incoming route      | Rule                      |
--------------------+---------------------------+
/legacy/*           | -> Legacy IIS site        |
/api/customers/*    | -> Customer API           |
/api/invoices/*     | -> Invoice API            |
/jobs/*             | -> Worker admin endpoints |
```

## Guardrails for each migrated slice

- Contract tests between gateway and backend.
- Health endpoint and dependency checks.
- Structured logging with correlation IDs.
- Feature flag + rollback path documented.
- Runbook updated before go-live.

## Definition of done for a slice

- [ ] Route cut-over performed in production safely.
- [ ] p95 latency and error rate meet baseline target.
- [ ] Rollback tested in non-prod.
- [ ] Legacy path decommission decision recorded.

Next: [03-Local-Dev-Setup.md](./03-Local-Dev-Setup.md)
