# Modernising VB6 Web Apps: Overview

If you built and supported VB6-era web systems, you have probably seen this stack in production:

- Classic ASP pages (`.asp`) serving HTML and forms.
- COM or COM+ business components (sometimes registered manually on servers).
- IIS as the front-end web server.
- ADO for data access.
- SQL Server with a mix of tables, views, and large stored procedures.
- Windows Scheduled Tasks, batch EXEs, and file-share integrations for operational work.

That stack often still works. The challenge is maintainability, deployment risk, and slow change speed.

> **Why this matters:** Modernisation is not about rewriting because old is bad. It is about reducing change risk, improving observability, and delivering features faster without breaking the business.

## What “modernising VB6 web apps” usually means

In practical terms, modernisation means introducing a **parallel modern platform** (typically ASP.NET Core + Web APIs + CI/CD + better monitoring) and moving functionality slice by slice.

Typical outcomes:

- Existing VB6/Classic ASP functionality keeps running while new modules move to .NET.
- Core business rules become testable services instead of hidden logic in ASP/COM glue code.
- Deployments become repeatable and automated.
- Logging and telemetry make incidents easier to detect and fix.

## Guiding principles

## 1) Avoid big-bang rewrites

Big-bang rewrites fail when assumptions drift and business rules are rediscovered too late.

Prefer:

- Small vertical slices (UI/API + business logic + data access) moved one module at a time.
- Routing old/new through a gateway boundary.
- Frequent production releases with low blast radius.

## 2) Deliver incremental value

Every modernisation step should have business value, for example:

- Faster report endpoint.
- More reliable overnight processing.
- Reduced support ticket volume on a specific module.

Avoid technical-only milestones that create risk without user-visible improvement.

## 3) Safety first: prove before replace

For each migrated slice:

- Add baseline metrics before migration.
- Run old and new paths side-by-side where possible.
- Use feature flags or controlled rollout.
- Keep rollback simple and tested.

## Recommended target architecture (high level)

```text
Users/Browsers
     |
     v
[Gateway / Reverse Proxy]
   |                    |
   v                    v
[Legacy IIS + ASP]   [New ASP.NET Core APIs]
   |                    |
   +---------+----------+
             v
        [SQL Server]
```

This keeps production stable while giving teams a clean path to move module by module.

## How to use this playbook

Start with discovery and risk mapping, then define your first migration slice, then make release/rollback a first-class design concern.

Read next: [01-Discovery-Checklist.md](./01-Discovery-Checklist.md).
