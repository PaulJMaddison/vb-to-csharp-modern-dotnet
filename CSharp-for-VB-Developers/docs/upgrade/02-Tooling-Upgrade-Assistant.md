# 02 - Tooling: Upgrade Assistant

The **.NET Upgrade Assistant** helps automate portions of migration from .NET Framework projects to modern .NET.

It is valuable for generating a first-pass upgrade and surfacing issues quickly, but it is not a complete migration substitute for architecture and behavior validation.

## Ways to use Upgrade Assistant

## 1) Visual Studio extension
- Useful when you want guided, project-by-project actions in an IDE workflow.
- Good for teams that prefer interactive prompts and immediate code fixes.

## 2) CLI workflow
- Useful for scripted runs, CI experimentation, and repeatable migration exercises.
- Better for larger multi-project solutions where you want process automation.

Example command:

```bash
upgrade-assistant upgrade <path>
```

Where `<path>` can be a project file or solution file.

## Typical workflow

1. **Assess**
   - Run Upgrade Assistant and inspect generated recommendations.
   - Record incompatible packages/APIs and estimate manual effort.

2. **Upgrade project structure and targets**
   - Convert to SDK-style project where applicable.
   - Move to modern target framework(s), often in stages for complex solutions.

3. **Fix package/API gaps**
   - Replace unsupported packages.
   - Refactor code for API differences and obsolete patterns.
   - Adjust platform targeting for Windows-only workloads.

4. **Validate behavior and operations**
   - Build, test, and smoke-test app behavior.
   - Verify logging/config/auth/hosting/deployment in target environments.

## What Upgrade Assistant can do automatically
Depending on project type and state, it can often:
- Analyze project readiness and surface known incompatibilities.
- Update project files and target frameworks.
- Migrate some package references and config patterns.
- Apply selected code fixers for known API changes.

## What remains manual
Expect human work for:
- Architectural shifts (System.Web to ASP.NET Core pipeline).
- WCF/remoting/AppDomain redesign.
- Complex auth/authorization migration.
- Hosting and deployment model changes.
- Integration behavior, performance tuning, and production hardening.

## Common gotchas

- **False confidence from a successful compile**
  - Build success does not guarantee functional equivalence; runtime and integration checks are mandatory.

- **Package version drift across solution projects**
  - Different upgrade timing can produce mismatched dependency versions. Centralize package versions early.

- **Configuration assumptions**
  - Legacy settings in config files may not map 1:1 to modern configuration providers.

- **Windows-only dependencies hidden in utility code**
  - Small helper libraries sometimes contain registry/path/service APIs that break cross-platform assumptions.

- **Authentication and middleware ordering changes**
  - Especially relevant when moving web projects; behavior can differ based on middleware pipeline order.

- **Designer- and resource-driven desktop behavior changes**
  - WinForms/WPF projects may build but have runtime resource/settings issues requiring manual fixes.

## Practical team tips
- Treat Upgrade Assistant output as a **work backlog**, not a complete migration plan.
- Pilot on one representative project before solution-wide execution.
- Capture recurring fixes in internal docs/scripts to reduce repeated manual work.
- Keep upgrade PRs focused and small enough for clear review/rollback.
