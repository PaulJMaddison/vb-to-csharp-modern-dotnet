# Modernisation Overview (for VB6 Teams)

This playbook is for teams running stable VB6/Classic ASP systems that now need safer releases, better observability, and faster feature delivery.

## Modernisation goals

- Keep business-critical workflows running while you modernise.
- Move from tightly coupled UI + data logic to testable API/service boundaries.
- Improve deployment safety (repeatable deploys + rollback).
- Reduce person-risk by documenting architecture and release process.

## What “modernisation” means in practice

For most VB6 estates, modernisation is **not** a rewrite. It is a staged migration where:

1. Existing IIS apps and SQL Server remain in place.
2. New functionality is delivered in ASP.NET Core APIs/workers.
3. A gateway routes selected paths from legacy to new services.
4. Modules move one-by-one (strangler fig pattern).

## Recommended migration posture

- **Start with one vertical slice** (UI/API + logic + data access).
- **Keep shared database initially** to lower risk and avoid schema churn.
- **Release frequently** with small blast radius.
- **Treat rollback as a feature** from day one.

## Target transition architecture

```text
Users/Browsers
      |
      v
+---------------------------+
| Gateway / Reverse Proxy   |
+-------------+-------------+
              |
      +-------+-------+
      |               |
      v               v
Legacy IIS      ASP.NET Core APIs
(VB6/ASP)        + Worker Services
      \               /
       +-------------+
             |
             v
         SQL Server
```

## Common anti-patterns to avoid

- Big-bang rewrite with delayed production feedback.
- Migrating infrastructure and functionality at the same time.
- Moving to microservices before boundaries are understood.
- Replacing DB schema and app logic simultaneously.

## Suggested reading order

1. [01-Discovery-Checklist.md](./01-Discovery-Checklist.md)
2. [02-Strangler-Fig-Approach.md](./02-Strangler-Fig-Approach.md)
3. [03-Local-Dev-Setup.md](./03-Local-Dev-Setup.md)
4. [04-Hosting-WebApis-and-Workers.md](./04-Hosting-WebApis-and-Workers.md)
5. [05-Database-Migration-Strategy.md](./05-Database-Migration-Strategy.md)
6. [06-Release-and-Rollback.md](./06-Release-and-Rollback.md)
7. [07-12-to-24-Month-Roadmap.md](./07-12-to-24-Month-Roadmap.md)
