# 01 - Upgrade Overview: .NET Framework to Modern .NET

Upgrading from .NET Framework 4.5+ to .NET 8+ is both a **runtime transition** and an **application model transition**.

The biggest mindset shift is this: in modern .NET, many workloads that used to depend on Windows-only framework features now run on a cross-platform runtime and use newer hosting/configuration/DI patterns.

## What changes when moving to modern .NET

## Runtime and framework model
- **From:** .NET Framework (Windows-only, machine-level install, GAC-centric ecosystem).
- **To:** Modern .NET (self-contained or framework-dependent deployment, side-by-side runtimes, faster release cadence).

## Project system
- **From:** legacy non-SDK `.csproj/.vbproj` style with verbose XML and packages.config.
- **To:** SDK-style project files with simpler configuration and centralized package management options.

## Configuration and hosting
- **From:** `web.config/app.config`, IIS-centric assumptions, older startup patterns.
- **To:** generic host model, `appsettings.json`, environment-based config, built-in DI/logging abstractions.

## API surface and platform assumptions
- Many APIs are equivalent, but some are changed, moved, deprecated, or unavailable.
- Platform-specific features still exist, but need explicit targeting and packaging choices.

## Common blockers to identify early
These are frequent friction points during upgrades:

- **System.Web dependencies**
  - `HttpContext.Current`, `HttpModules`, `HttpHandlers`, session assumptions, and pipeline hooks.
- **AppDomains and remoting**
  - Legacy isolation and remoting approaches generally need redesign (process boundaries, messaging, or modern service boundaries).
- **WCF server-side usage**
  - Existing WCF services often need migration strategy (ASP.NET Core APIs, gRPC, or compatibility bridges).
- **Registry and file permissions assumptions**
  - Hard-coded writes to Program Files, machine registry hives, or elevated locations often fail under modern deployment and container models.
- **Windows-only technology coupling**
  - COM interop, old Office automation, or unmanaged dependencies may lock projects to Windows and affect upgrade order.
- **Third-party package availability**
  - NuGet packages may not support net8.0 or may require major-version upgrades with breaking changes.

## Recommended upgrade order: where you can go first
A practical sequence for most enterprise solutions:

1. **Libraries first (low UI coupling)**
   - Utility projects, domain logic, DTO packages, and cross-cutting libs.
   - Goal: reduce dependency surface and establish netstandard/net8-compatible cores.

2. **Services and background workloads next**
   - APIs, worker jobs, integrations.
   - Goal: adopt modern hosting, diagnostics, deployment pipelines, and security patterns.

3. **UI applications last**
   - WinForms/WPF or ASP.NET Framework apps.
   - Goal: move high-coupling presentation layers once backend contracts are stable.

This ordering lets teams modernize architecture edges first, then migrate high-risk UI code with less uncertainty.

## Simple upgrade decision tree
Use this quick triage model per project:

1. **Is the project a class library with minimal framework-specific APIs?**
   - **Yes:** attempt direct upgrade to modern target framework.
   - **No:** continue.

2. **Does it depend on System.Web or ASP.NET Framework pipeline features?**
   - **Yes:** treat as migration to ASP.NET Core (partial rewrite of hosting/pipeline likely).
   - **No:** continue.

3. **Is it a desktop UI app (WinForms/WPF) with Windows dependencies?**
   - **Yes:** use Windows-targeted modern .NET path (`net8.0-windows`) and validate designer/resources/settings behavior.
   - **No:** continue.

4. **Does it rely on remoting/AppDomains/WCF server features?**
   - **Yes:** schedule architecture redesign tasks before or during upgrade.
   - **No:** continue.

5. **Are critical NuGet/vendor dependencies available for modern .NET?**
   - **Yes:** proceed with assisted upgrade + test hardening.
   - **No:** consider temporary compatibility boundary, replacement library, or deferred project wave.

## Practical success criteria
Before calling a project “upgraded,” confirm:
- Build + tests are green in CI.
- Runtime behavior is validated in a realistic environment.
- Observability (logging/metrics/tracing) is in place.
- Deployment and rollback are documented and rehearsed.
