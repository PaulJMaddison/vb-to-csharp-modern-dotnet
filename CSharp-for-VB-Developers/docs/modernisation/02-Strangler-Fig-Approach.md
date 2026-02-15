# Strangler Fig Approach (Deep Dive)

The Strangler Fig approach modernises legacy systems by surrounding the old system and replacing functionality in controlled slices.

Instead of replacing everything at once, you route selected requests to new services while the rest stays on legacy.

> **Why this matters:** It lowers migration risk, keeps business continuity, and gives fast feedback on each slice.

## Core idea

1. Put a routing boundary in front of legacy and new systems.
2. Move one module/workflow at a time.
3. Validate behavior with telemetry and user feedback.
4. Increase migrated scope over time.
5. Decommission legacy modules when confidence is high.

## Before/after diagrams

### Before

```text
Browser
   |
   v
[IIS + Classic ASP]
   |
   v
[COM Components] ---> [Shared Files]
   |
   v
[SQL Server]
```

### During migration (Strangler phase)

```text
Browser
   |
   v
[Gateway / Reverse Proxy]
   |                      \
   v                       v
[Legacy IIS + ASP]     [ASP.NET Core APIs]
   |                       |
   +-----------+-----------+
               v
          [SQL Server]
```

### After major slices migrated

```text
Browser
   |
   v
[Gateway]
   |
   v
[ASP.NET Core APIs + Workers]
   |
   v
[SQL Server + New Data Services]
```

## Routing boundary patterns

## 1) Reverse proxy/gateway (YARP)

Use a single entry point that forwards requests to legacy or modern backends.

Typical benefits:

- Central routing control.
- One place for auth, correlation IDs, and rate limiting (later).
- Ability to flip module routes without changing clients.

Example module route intent:

- `/orders/*` -> new API
- `/invoices/*` -> legacy app
- `/customers/*` -> split by endpoint maturity

## 2) Path-based routing per module

Path-based routing is the simplest strangler boundary.

Example strategy:

- Phase 1: `/api/customers/*` -> new service; all else legacy.
- Phase 2: `/api/orders/*` -> new service.
- Phase 3: `/reporting/*` -> new service.

Keep route ownership explicit in a migration map.

## Step-by-step workflow

## Step 1: Pick a first slice

Best first slices are:

- High pain but bounded logic.
- Low cross-module coupling.
- Clear success metrics.

Good examples: customer lookup, order status endpoint, read-only reporting API.

## Step 2: Build parity tests and acceptance criteria

Define expected outputs (including edge cases) from legacy behavior.

- Golden test data for representative requests.
- Field-level comparison where feasible.
- Explicit handling for known legacy quirks.

## Step 3: Implement new slice behind gateway route

- Create ASP.NET Core module/API.
- Route only target path to new module.
- Keep non-target paths on legacy.

## Step 4: Controlled rollout

- Start with internal users or one business unit.
- Monitor error rate + latency + business KPIs.
- Expand traffic gradually.

## Step 5: Cut over and decommission

After stable period:

- Move all traffic for the slice to new path.
- Remove duplicate legacy code.
- Update runbooks and support docs.

## Practical slice migration examples

## Example A: Customer search

- Legacy: `customers.asp?query=...`
- New: `/api/customers/search?q=...`
- Gateway:
  - UI path can stay legacy initially.
  - API path for search goes new first.

Outcome: measurable latency and reliability improvement with minimal user workflow change.

## Example B: Invoice status

- Legacy invoice generation remains unchanged.
- New API serves invoice status read model.
- Support team gets faster status checks without touching invoice posting logic.

## Anti-patterns (and why they fail)

1. **Big-bang branch for 9+ months**
   - Fails due to drift, merge risk, and delayed feedback.

2. **No explicit routing ownership**
   - Causes accidental traffic movement and hard-to-debug incidents.

3. **Dual writes without reconciliation strategy**
   - Creates silent data divergence.

4. **Migrating hardest module first**
   - Delays wins and kills confidence.

5. **No telemetry before cutover**
   - You cannot prove regression or improvement.

## Quick readiness checklist for each slice

- [ ] Route boundary defined.
- [ ] Parity tests agreed.
- [ ] Baseline metrics captured.
- [ ] Rollback toggle available.
- [ ] Support team informed with runbook.

Read next: [03-Local-Dev-Setup.md](./03-Local-Dev-Setup.md).
