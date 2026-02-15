# C# and Modern .NET for VB6 Developers – Modernisation Starter Kit

## Table of Contents
- [Overview](#overview)
- [🚀 Quick Start – Run the Lab](#-quick-start--run-the-lab)
- [🧭 Learning Path (Start Here)](#-learning-path-start-here)
- [🧱 Application Types Explained](#-application-types-explained)
- [🏗️ Modernisation Playbook](#️-modernisation-playbook)
- [🧪 Testing & Quality](#-testing--quality)
- [📘 Tutorials](#-tutorials)
- [🧰 Patterns & Practices](#-patterns--practices)
- [📚 Documentation Hub (All `/docs` Content)](#-documentation-hub-all-docs-content)
- [🤝 Contributing](#-contributing)
- [📊 Ports & Endpoints Reference](#-ports--endpoints-reference)
- [Suggested Reading Order for VB6 Developers](#suggested-reading-order-for-vb6-developers)

## Overview
This repository is a training platform and a modernisation reference for experienced VB6 and
VB Windows developers moving to modern C#/.NET and web/cloud delivery.

It is designed to help teams modernise safely and incrementally by showing practical patterns for:
- Desktop applications (WinForms)
- Web UI applications (Razor Pages, MVC, Blazor)
- Backend APIs (ASP.NET Core Web API)
- Gateway-based routing (Reverse Proxy)
- Background processing (Worker Services)

The examples and guides support Strangler-style migration so teams can replace VB6 modules in
small, controlled slices instead of risky big-bang rewrites.

## 🚀 Quick Start – Run the Lab
Use the provided scripts to start the local lab environment.

PowerShell:

```powershell
./CSharp-for-VB-Developers/scripts/run-lab.ps1
```

bash:

```bash
./CSharp-for-VB-Developers/scripts/run-lab.sh
```

This starts the Gateway and APIs for the workshop environment.
- Swagger endpoints are available for API exploration.
- Health endpoints are available for service checks.
- Port assignments and URL mappings are defined in:
  - [`docs/ports-and-urls.md`](CSharp-for-VB-Developers/docs/ports-and-urls.md)

## 🧭 Learning Path (Start Here)
Start with the guided workshop path:
- [`docs/learning-path/README.md`](CSharp-for-VB-Developers/docs/learning-path/README.md)

Use the exercise index for planning and progress tracking:
- [`docs/learning-path/EXERCISES-INDEX.md`](CSharp-for-VB-Developers/docs/learning-path/EXERCISES-INDEX.md)

## 🧱 Application Types Explained
If you are coming from VB6/VB Windows apps, begin with these architecture overviews:
- [`docs/App-Types-Overview.md`](CSharp-for-VB-Developers/docs/App-Types-Overview.md)
- [`docs/foundations/Windows-vs-Web-Development.md`](CSharp-for-VB-Developers/docs/foundations/Windows-vs-Web-Development.md)

Application types covered in this repo:
- Desktop
  - WinForms
- Web UI
  - Razor Pages
  - MVC
  - Blazor
- Backend
  - Web API
- Background
  - Worker Services
- Gateway
  - Reverse Proxy

## 🏗️ Modernisation Playbook
This playbook shows how to migrate VB6 applications incrementally.

- [`docs/modernisation/00-Modernisation-Overview.md`](CSharp-for-VB-Developers/docs/modernisation/00-Modernisation-Overview.md)
- [`docs/modernisation/01-Discovery-Checklist.md`](CSharp-for-VB-Developers/docs/modernisation/01-Discovery-Checklist.md)
- [`docs/modernisation/02-Strangler-Fig-Approach.md`](CSharp-for-VB-Developers/docs/modernisation/02-Strangler-Fig-Approach.md)
- [`docs/modernisation/03-Local-Dev-Setup.md`](CSharp-for-VB-Developers/docs/modernisation/03-Local-Dev-Setup.md)
- [`docs/modernisation/04-Hosting-WebApis-and-Workers.md`](CSharp-for-VB-Developers/docs/modernisation/04-Hosting-WebApis-and-Workers.md)
- [`docs/modernisation/05-Database-Migration-Strategy.md`](CSharp-for-VB-Developers/docs/modernisation/05-Database-Migration-Strategy.md)
- [`docs/modernisation/06-Release-and-Rollback.md`](CSharp-for-VB-Developers/docs/modernisation/06-Release-and-Rollback.md)
- [`docs/modernisation/07-12-to-24-Month-Roadmap.md`](CSharp-for-VB-Developers/docs/modernisation/07-12-to-24-Month-Roadmap.md)

## 🧪 Testing & Quality
Quality standards for modernised modules:
- [`docs/standards/definition-of-done.md`](CSharp-for-VB-Developers/docs/standards/definition-of-done.md)
- [`docs/standards/style-and-structure.md`](CSharp-for-VB-Developers/docs/standards/style-and-structure.md)

All modernised modules should include:
- API endpoints
- Logging
- Health checks
- Integration tests
- Gateway routing

## 📘 Tutorials
For side-by-side VB6 vs C# examples, start here:
- [`docs/tutorials/VB6-to-CSharp-Tutorial.md`](CSharp-for-VB-Developers/docs/tutorials/VB6-to-CSharp-Tutorial.md)

## 🧰 Patterns & Practices
Pattern references live under:
- [`docs/patterns/`](CSharp-for-VB-Developers/docs/patterns/)

Topics include:
- Dependency Injection (DI)
- Configuration
- Logging
- Error Handling
- Data Access

## 📚 Documentation Hub (All `/docs` Content)
Use this section as the single navigation hub for all documentation.

### Core Guides
- [`docs/App-Types-Overview.md`](CSharp-for-VB-Developers/docs/App-Types-Overview.md)
- [`docs/ports-and-urls.md`](CSharp-for-VB-Developers/docs/ports-and-urls.md)
- [`docs/VB-to-CSharp-Cheatsheet.md`](CSharp-for-VB-Developers/docs/VB-to-CSharp-Cheatsheet.md)

### Foundations
- [`docs/foundations/Windows-vs-Web-Development.md`](CSharp-for-VB-Developers/docs/foundations/Windows-vs-Web-Development.md)

### Learning Path
- [`docs/learning-path/README.md`](CSharp-for-VB-Developers/docs/learning-path/README.md)
- [`docs/learning-path/EXERCISES-INDEX.md`](CSharp-for-VB-Developers/docs/learning-path/EXERCISES-INDEX.md)
- [`docs/learning-path/01-Getting-Set-Up.md`](CSharp-for-VB-Developers/docs/learning-path/01-Getting-Set-Up.md)
- [`docs/learning-path/01-Setup.md`](CSharp-for-VB-Developers/docs/learning-path/01-Setup.md)
- [`docs/learning-path/02-CSharp-Quick-Wins.md`](CSharp-for-VB-Developers/docs/learning-path/02-CSharp-Quick-Wins.md)
- [`docs/learning-path/03-WebApi-Basics-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/03-WebApi-Basics-Lab.md)
- [`docs/learning-path/04-Auth-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/04-Auth-Lab.md)
- [`docs/learning-path/05-Testing-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/05-Testing-Lab.md)
- [`docs/learning-path/05-Integration-Testing-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/05-Integration-Testing-Lab.md)
- [`docs/learning-path/06-Gateway-Strangler-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/06-Gateway-Strangler-Lab.md)
- [`docs/learning-path/07-Data-Access-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/07-Data-Access-Lab.md)
- [`docs/learning-path/08-Web-UI-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/08-Web-UI-Lab.md)
- [`docs/learning-path/09-Worker-Background-Jobs-Lab.md`](CSharp-for-VB-Developers/docs/learning-path/09-Worker-Background-Jobs-Lab.md)
- [`docs/learning-path/10-Capstone-Project.md`](CSharp-for-VB-Developers/docs/learning-path/10-Capstone-Project.md)

### Modernisation
- [`docs/modernisation/00-Modernisation-Overview.md`](CSharp-for-VB-Developers/docs/modernisation/00-Modernisation-Overview.md)
- [`docs/modernisation/01-Discovery-Checklist.md`](CSharp-for-VB-Developers/docs/modernisation/01-Discovery-Checklist.md)
- [`docs/modernisation/02-Strangler-Fig-Approach.md`](CSharp-for-VB-Developers/docs/modernisation/02-Strangler-Fig-Approach.md)
- [`docs/modernisation/03-Local-Dev-Setup.md`](CSharp-for-VB-Developers/docs/modernisation/03-Local-Dev-Setup.md)
- [`docs/modernisation/04-Hosting-WebApis-and-Workers.md`](CSharp-for-VB-Developers/docs/modernisation/04-Hosting-WebApis-and-Workers.md)
- [`docs/modernisation/05-Database-Migration-Strategy.md`](CSharp-for-VB-Developers/docs/modernisation/05-Database-Migration-Strategy.md)
- [`docs/modernisation/06-Release-and-Rollback.md`](CSharp-for-VB-Developers/docs/modernisation/06-Release-and-Rollback.md)
- [`docs/modernisation/07-12-to-24-Month-Roadmap.md`](CSharp-for-VB-Developers/docs/modernisation/07-12-to-24-Month-Roadmap.md)

### Patterns
- [`docs/patterns/configuration-and-secrets.md`](CSharp-for-VB-Developers/docs/patterns/configuration-and-secrets.md)
- [`docs/patterns/data-access-ef-vs-dapper.md`](CSharp-for-VB-Developers/docs/patterns/data-access-ef-vs-dapper.md)
- [`docs/patterns/dependency-injection.md`](CSharp-for-VB-Developers/docs/patterns/dependency-injection.md)
- [`docs/patterns/error-handling-problemdetails.md`](CSharp-for-VB-Developers/docs/patterns/error-handling-problemdetails.md)
- [`docs/patterns/logging-and-correlation.md`](CSharp-for-VB-Developers/docs/patterns/logging-and-correlation.md)
- [`docs/patterns/reverse-proxy-gateway.md`](CSharp-for-VB-Developers/docs/patterns/reverse-proxy-gateway.md)
- [`docs/patterns/testing-unit-vs-integration.md`](CSharp-for-VB-Developers/docs/patterns/testing-unit-vs-integration.md)

### Standards
- [`docs/standards/definition-of-done.md`](CSharp-for-VB-Developers/docs/standards/definition-of-done.md)
- [`docs/standards/style-and-structure.md`](CSharp-for-VB-Developers/docs/standards/style-and-structure.md)

### Tutorials
- [`docs/tutorials/VB6-to-CSharp-Tutorial.md`](CSharp-for-VB-Developers/docs/tutorials/VB6-to-CSharp-Tutorial.md)

## 🤝 Contributing
To contribute examples, docs, or labs, see:
- [`CONTRIBUTING.md`](CSharp-for-VB-Developers/CONTRIBUTING.md)

## 📊 Ports & Endpoints Reference
For local port assignments and endpoint URLs, see:
- [`docs/ports-and-urls.md`](CSharp-for-VB-Developers/docs/ports-and-urls.md)

## Suggested Reading Order for VB6 Developers
1. [`docs/tutorials/VB6-to-CSharp-Tutorial.md`](CSharp-for-VB-Developers/docs/tutorials/VB6-to-CSharp-Tutorial.md)
2. [`docs/foundations/Windows-vs-Web-Development.md`](CSharp-for-VB-Developers/docs/foundations/Windows-vs-Web-Development.md)
3. [`docs/App-Types-Overview.md`](CSharp-for-VB-Developers/docs/App-Types-Overview.md)
4. [`docs/learning-path/README.md`](CSharp-for-VB-Developers/docs/learning-path/README.md)
5. [`docs/modernisation/02-Strangler-Fig-Approach.md`](CSharp-for-VB-Developers/docs/modernisation/02-Strangler-Fig-Approach.md)
