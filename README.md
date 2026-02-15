# C# and Modern .NET for VB.NET Developers on .NET Framework

## Overview
This repository is a practical modernisation lab for teams moving from **VB.NET on .NET Framework 4.5+** to modern C# and .NET 8.

It keeps working reference projects across desktop, web, API, gateway, worker, and testing so teams can modernise incrementally instead of rewriting all at once.

## What this repo is for
- **Language transition:** VB.NET -> C# patterns, idioms, and standards.
- **Application model reference:** side-by-side examples for WinForms, Web UI, APIs, Worker Services, and gateway routing.
- **Migration patterns:** incremental delivery using strangler and facade approaches.
- **Upgrade path:** .NET Framework workloads moving toward .NET 8 with practical constraints.

## Audience
- Windows application teams with VB.NET codebases on .NET Framework 4.5+.
- Teams that already have some MVC/Blazor exposure and now need shared standards and modernization sequencing.

## 🚀 Run the lab
PowerShell:

```powershell
./CSharp-for-VB-Developers/scripts/run-lab.ps1
```

bash:

```bash
./CSharp-for-VB-Developers/scripts/run-lab.sh
```

Ports/endpoints: [`docs/ports-and-urls.md`](CSharp-for-VB-Developers/docs/ports-and-urls.md)

## Recommended learning path
1. VB.NET -> C# tutorial: [`docs/tutorials/VBNet-to-CSharp-Tutorial.md`](CSharp-for-VB-Developers/docs/tutorials/VBNet-to-CSharp-Tutorial.md)
2. Architecture refresher: [`docs/foundations/Windows-vs-Web-Development.md`](CSharp-for-VB-Developers/docs/foundations/Windows-vs-Web-Development.md)
3. App model guide: [`docs/App-Types-Overview.md`](CSharp-for-VB-Developers/docs/App-Types-Overview.md)
4. Team labs and standards: [`docs/learning-path/README.md`](CSharp-for-VB-Developers/docs/learning-path/README.md)
5. Incremental modernisation playbook: [`docs/modernisation/00-Modernisation-Overview.md`](CSharp-for-VB-Developers/docs/modernisation/00-Modernisation-Overview.md)

## Docs hub
### Core
- [`docs/VB-to-CSharp-Cheatsheet.md`](CSharp-for-VB-Developers/docs/VB-to-CSharp-Cheatsheet.md)
- [`docs/App-Types-Overview.md`](CSharp-for-VB-Developers/docs/App-Types-Overview.md)
- [`docs/ports-and-urls.md`](CSharp-for-VB-Developers/docs/ports-and-urls.md)

### Learning path (reference + refresher)
- [`docs/learning-path/README.md`](CSharp-for-VB-Developers/docs/learning-path/README.md)
- [`docs/learning-path/EXERCISES-INDEX.md`](CSharp-for-VB-Developers/docs/learning-path/EXERCISES-INDEX.md)

### Modernisation playbook
- [`docs/modernisation/00-Modernisation-Overview.md`](CSharp-for-VB-Developers/docs/modernisation/00-Modernisation-Overview.md)
- [`docs/modernisation/01-Discovery-Checklist.md`](CSharp-for-VB-Developers/docs/modernisation/01-Discovery-Checklist.md)
- [`docs/modernisation/02-Strangler-Fig-Approach.md`](CSharp-for-VB-Developers/docs/modernisation/02-Strangler-Fig-Approach.md)
- [`docs/modernisation/03-Local-Dev-Setup.md`](CSharp-for-VB-Developers/docs/modernisation/03-Local-Dev-Setup.md)
- [`docs/modernisation/04-Hosting-WebApis-and-Workers.md`](CSharp-for-VB-Developers/docs/modernisation/04-Hosting-WebApis-and-Workers.md)
- [`docs/modernisation/05-Database-Migration-Strategy.md`](CSharp-for-VB-Developers/docs/modernisation/05-Database-Migration-Strategy.md)
- [`docs/modernisation/06-Release-and-Rollback.md`](CSharp-for-VB-Developers/docs/modernisation/06-Release-and-Rollback.md)
- [`docs/modernisation/07-12-to-24-Month-Roadmap.md`](CSharp-for-VB-Developers/docs/modernisation/07-12-to-24-Month-Roadmap.md)

### Web/API/cloud patterns
- [`docs/patterns/`](CSharp-for-VB-Developers/docs/patterns/)

## Contributing
- [`CONTRIBUTING.md`](CSharp-for-VB-Developers/CONTRIBUTING.md)
