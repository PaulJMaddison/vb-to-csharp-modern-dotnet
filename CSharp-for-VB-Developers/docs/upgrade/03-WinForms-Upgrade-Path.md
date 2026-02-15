# 03 - WinForms Upgrade Path (.NET Framework -> Modern .NET)

Upgrading WinForms applications from .NET Framework to modern .NET is typically feasible, but it requires careful handling of Windows-specific details.

## Windows-only note
WinForms on modern .NET is a **Windows-only** UI stack.

For upgraded projects, you generally target a Windows-specific framework moniker such as:
- `net8.0-windows`

This is expected and does not prevent modernization; it simply reflects platform reality.

## What changes in the project file
When moving from legacy project format to SDK-style, you can expect:
- Simpler project XML.
- Explicit WinForms enablement.
- Modern target framework declaration.
- Updated package reference model.

Common project-level adjustments include:
- Target framework changed to a Windows-specific modern target.
- WinForms usage enabled in project properties.
- Resource/designer metadata normalized during conversion.

## Resources and settings considerations
WinForms upgrades often surface issues in:
- `Resources.resx` access patterns and generated designer code.
- `Settings.settings` defaults and user-scope persistence behavior.
- Satellite resource loading and localization assumptions.
- Old custom build actions tied to legacy tooling.

Practical guidance:
- Validate localized builds early.
- Open representative forms in the designer and run smoke tests.
- Watch for subtle font/layout differences on newer runtime + DPI settings.

## Suggested sequence for VB.NET WinForms apps

1. **Inventory the solution**
   - Split projects into UI, shared libraries, integrations, and data access.
   - Flag COM interop, third-party controls, and native dependencies.

2. **Upgrade non-UI dependencies first**
   - Move shared libraries to modern-compatible targets.
   - Reduce legacy API usage before touching UI projects.

3. **Create a WinForms pilot upgrade**
   - Pick one medium-complexity app/module.
   - Run Upgrade Assistant and apply project conversion.

4. **Fix build and designer/resource issues**
   - Resolve package/API incompatibilities.
   - Validate form initialization, resources, settings, and startup behavior.

5. **Harden runtime behavior**
   - Exercise core user workflows, printing/export/integration paths, and error handling.
   - Add/expand automated tests around non-UI logic.

6. **Roll out by wave**
   - Upgrade additional WinForms apps after establishing reusable patterns.
   - Standardize project templates and CI/CD checks across the portfolio.

## Frequent risk areas
- Third-party WinForms controls without modern .NET support.
- COM dependencies requiring 32-bit assumptions.
- Installer and update mechanisms tied to old runtime prerequisites.
- Machine-level file/registry writes that conflict with modern security expectations.

## Success checklist for each WinForms app
- App builds and launches on target Windows versions.
- Core workflows pass user acceptance tests.
- Resource/localization behavior is verified.
- Installer/deployment path is updated for modern runtime strategy.
- Support and rollback procedures are documented.
