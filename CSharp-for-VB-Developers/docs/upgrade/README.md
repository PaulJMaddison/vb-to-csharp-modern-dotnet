# .NET Framework -> .NET 8 Upgrade Training

This section is a practical training track for teams upgrading existing **VB.NET applications on .NET Framework 4.5+** to **modern .NET (8+)**.

It is intentionally written for real production constraints: large solutions, legacy dependencies, mixed UI + service stacks, and limited rewrite budgets.

## Who this is for
- VB.NET developers and leads maintaining .NET Framework 4.5+ applications.
- Teams that need to modernize safely while still shipping features.
- Architects/planners sequencing upgrades across shared libraries, services, and user-facing apps.

> This is **not** a VB6 migration guide. It assumes a VB.NET/.NET Framework baseline.

## Recommended approach
Use an **incremental modernization strategy** supported by **upgrade tooling**:
1. Assess and categorize projects by complexity and risk.
2. Upgrade low-friction class libraries first.
3. Move service/API layers next to establish modern hosting, config, logging, and deployment patterns.
4. Tackle UI applications with platform-specific planning (WinForms/WPF/ASP.NET Framework).
5. Validate every step with tests, observability, and rollback planning.

This reduces operational risk compared with a big-bang rewrite and gives teams early value.

## Documents in this section
- [01 - Upgrade Overview](./01-Upgrade-Overview.md)
- [02 - Tooling: Upgrade Assistant](./02-Tooling-Upgrade-Assistant.md)
- [03 - WinForms Upgrade Path](./03-WinForms-Upgrade-Path.md)
- [04 - ASP.NET Framework to ASP.NET Core](./04-ASP.NET-Framework-to-Core.md)
- [05 - Compatibility Checklist](./05-Compatibility-Checklist.md)

## Suggested reading order
1. **Start here:** [01 - Upgrade Overview](./01-Upgrade-Overview.md)
2. **Plan execution tooling:** [02 - Tooling: Upgrade Assistant](./02-Tooling-Upgrade-Assistant.md)
3. **Choose app path:**
   - Desktop teams: [03 - WinForms Upgrade Path](./03-WinForms-Upgrade-Path.md)
   - Web teams: [04 - ASP.NET Framework to ASP.NET Core](./04-ASP.NET-Framework-to-Core.md)
4. **Run readiness and exit checks:** [05 - Compatibility Checklist](./05-Compatibility-Checklist.md)

## How to use this training content with your team
- Run a short architecture review and fill the compatibility checklist first.
- Pick one pilot project and complete a full upgrade cycle before scaling.
- Capture lessons learned as reusable templates (project files, CI jobs, deployment runbooks).
- Expand to higher-complexity projects once the team has a repeatable path.
