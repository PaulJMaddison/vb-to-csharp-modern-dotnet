# 05 - Compatibility Checklist

Use this checklist before and after each project upgrade wave.

It is designed for VB.NET/.NET Framework teams modernizing incrementally to .NET 8+.

## Pre-upgrade checklist

## 1) Project and dependency inventory
- [ ] List all projects in the solution (libraries, services, UI, tests, tooling).
- [ ] Identify current target frameworks and project formats.
- [ ] Inventory NuGet packages and vendor libraries; mark modern .NET support status.
- [ ] Flag transitive dependencies that may hide unsupported APIs.

## 2) API and framework usage analysis
- [ ] Identify usage of `System.Web`, remoting, AppDomains, WCF server components.
- [ ] Identify registry, file system, and machine-level permission assumptions.
- [ ] Identify Windows-only dependencies (COM, Office automation, native DLLs).
- [ ] Check serialization, reflection, and dynamic loading patterns for compatibility risk.

## 3) Runtime and OS dependency analysis
- [ ] Confirm required OS targets (Windows-only vs cross-platform intent).
- [ ] Confirm architecture constraints (x86/x64/AnyCPU) and native interop expectations.
- [ ] Validate external runtime prerequisites and installer assumptions.

## 4) Build and release readiness
- [ ] Ensure CI builds and test baselines are stable before migration.
- [ ] Capture current deployment topology and rollback mechanism.
- [ ] Define upgrade wave scope, owners, and acceptance criteria.

## Post-upgrade checklist

## 1) Configuration and environment
- [ ] Validate migration from legacy config patterns to modern configuration sources.
- [ ] Verify environment-specific overrides for dev/test/staging/prod.
- [ ] Confirm secrets handling and rotation strategy.

## 2) Hosting and runtime behavior
- [ ] Validate hosting model (service, IIS/Kestrel, Windows service, container, etc.).
- [ ] Verify startup, shutdown, and resilience behavior under expected load.
- [ ] Confirm runtime compatibility on target OS/runtime combinations.

## 3) Authentication and authorization
- [ ] Validate authentication flows end-to-end.
- [ ] Verify authorization policies/roles and middleware ordering behavior.
- [ ] Re-test session/token expiration and sign-out edge cases.

## 4) Logging, observability, and diagnostics
- [ ] Confirm structured logging is enabled and correlated.
- [ ] Validate metrics/tracing coverage for critical paths.
- [ ] Ensure error alerts and dashboards reflect the upgraded app.

## 5) Deployment and operations
- [ ] Validate deployment automation for the new runtime model.
- [ ] Confirm rollback procedures are tested and documented.
- [ ] Update runbooks, support documentation, and on-call guidance.

## 6) Tests and quality gates
- [ ] Run unit/integration/regression tests and compare baseline behavior.
- [ ] Execute smoke tests for critical user/business workflows.
- [ ] Confirm performance and resource usage are within acceptable thresholds.

## Exit criteria for an upgrade wave
- [ ] Functional parity verified for scoped features.
- [ ] Operational readiness verified (logs/alerts/deploy/rollback).
- [ ] Security and compliance checks completed.
- [ ] Stakeholder sign-off completed before expanding to next wave.
