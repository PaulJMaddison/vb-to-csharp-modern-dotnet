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
- [📚 Documentation Hub (All Docs)](#-documentation-hub-all-docs)
- [🤝 Contributing](#-contributing)
- [📊 Ports & Endpoints Reference](#-ports--endpoints-reference)
- [Suggested Reading Order for VB6 Developers](#suggested-reading-order-for-vb6-developers)

## Overview
This repository is a training kit and modernisation reference for VB6 teams.

It helps experienced VB6 Windows/Web developers move safely to modern C# and .NET
while delivering features during migration.

The samples cover common modern application patterns:
- Desktop
- Web UI
- API
- Gateway
- Worker

The guidance supports incremental Strangler migration so teams can modernise in
controlled steps instead of doing a single risky rewrite.

## 🚀 Quick Start – Run the Lab
Run from the repository root.

PowerShell:

```powershell
./scripts/run-lab.ps1
```

bash:

```bash
./scripts/run-lab.sh
```

This starts Gateway + APIs, with Swagger and health endpoints available.

Ports and URLs are documented in:
- [docs/ports-and-urls.md](docs/ports-and-urls.md)

## 🧭 Learning Path (Start Here)
This is the guided workshop path for VB6 developers.

- [docs/learning-path/README.md](docs/learning-path/README.md)
- [docs/learning-path/EXERCISES-INDEX.md](docs/learning-path/EXERCISES-INDEX.md)

## 🧱 Application Types Explained
Core concepts:
- [docs/App-Types-Overview.md](docs/App-Types-Overview.md)
- [docs/foundations/Windows-vs-Web-Development.md](docs/foundations/Windows-vs-Web-Development.md)

Application types included:
- Desktop: WinForms
- Web UI: Razor Pages, MVC, Blazor
- Backend: Web API
- Background: Worker Services
- Gateway: Reverse Proxy

## 🏗️ Modernisation Playbook
This sequence shows how to migrate VB6 apps incrementally.

- [docs/modernisation/00-Modernisation-Overview.md](docs/modernisation/00-Modernisation-Overview.md)
- [docs/modernisation/01-Discovery-Checklist.md](docs/modernisation/01-Discovery-Checklist.md)
- [docs/modernisation/02-Strangler-Fig-Approach.md](docs/modernisation/02-Strangler-Fig-Approach.md)
- [docs/modernisation/03-Local-Dev-Setup.md](docs/modernisation/03-Local-Dev-Setup.md)
- [04 Hosting Web APIs and Workers](docs/modernisation/04-Hosting-WebApis-and-Workers.md)
- [05 Database Migration Strategy](docs/modernisation/05-Database-Migration-Strategy.md)
- [docs/modernisation/06-Release-and-Rollback.md](docs/modernisation/06-Release-and-Rollback.md)
- [docs/modernisation/07-12-to-24-Month-Roadmap.md](docs/modernisation/07-12-to-24-Month-Roadmap.md)

## 🧪 Testing & Quality
Standards:
- [docs/standards/definition-of-done.md](docs/standards/definition-of-done.md)
- [docs/standards/style-and-structure.md](docs/standards/style-and-structure.md)

All modernised modules should include:
- API endpoints
- logging
- health checks
- integration tests
- gateway routing

## 📘 Tutorials
Side-by-side VB6 vs C# examples:
- [docs/tutorials/VB6-to-CSharp-Tutorial.md](docs/tutorials/VB6-to-CSharp-Tutorial.md)

## 🧰 Patterns & Practices
Pattern guidance folder:
- [docs/patterns/](docs/patterns/)

Focus topics:
- DI
- Configuration
- Logging
- Error Handling
- Data Access

## 📚 Documentation Hub (All Docs)
All documentation currently under `/docs`:

### Core
- [docs/App-Types-Overview.md](docs/App-Types-Overview.md)
- [docs/VB-to-CSharp-Cheatsheet.md](docs/VB-to-CSharp-Cheatsheet.md)

### Foundations
- [docs/foundations/Windows-vs-Web-Development.md](docs/foundations/Windows-vs-Web-Development.md)

### Learning Path
- [docs/learning-path/README.md](docs/learning-path/README.md)
- [docs/learning-path/EXERCISES-INDEX.md](docs/learning-path/EXERCISES-INDEX.md)
- [docs/learning-path/01-Getting-Set-Up.md](docs/learning-path/01-Getting-Set-Up.md)
- [docs/learning-path/01-Setup.md](docs/learning-path/01-Setup.md)
- [docs/learning-path/02-CSharp-Quick-Wins.md](docs/learning-path/02-CSharp-Quick-Wins.md)
- [docs/learning-path/03-WebApi-Basics-Lab.md](docs/learning-path/03-WebApi-Basics-Lab.md)
- [docs/learning-path/04-Auth-Lab.md](docs/learning-path/04-Auth-Lab.md)
- [05 Integration Testing Lab](docs/learning-path/05-Integration-Testing-Lab.md)
- [docs/learning-path/05-Testing-Lab.md](docs/learning-path/05-Testing-Lab.md)
- [docs/learning-path/06-Gateway-Strangler-Lab.md](docs/learning-path/06-Gateway-Strangler-Lab.md)
- [docs/learning-path/07-Data-Access-Lab.md](docs/learning-path/07-Data-Access-Lab.md)
- [docs/learning-path/08-Web-UI-Lab.md](docs/learning-path/08-Web-UI-Lab.md)
- [09 Worker Background Jobs Lab](docs/learning-path/09-Worker-Background-Jobs-Lab.md)
- [docs/learning-path/10-Capstone-Project.md](docs/learning-path/10-Capstone-Project.md)

### Modernisation
- [docs/modernisation/00-Modernisation-Overview.md](docs/modernisation/00-Modernisation-Overview.md)
- [docs/modernisation/01-Discovery-Checklist.md](docs/modernisation/01-Discovery-Checklist.md)
- [docs/modernisation/02-Strangler-Fig-Approach.md](docs/modernisation/02-Strangler-Fig-Approach.md)
- [docs/modernisation/03-Local-Dev-Setup.md](docs/modernisation/03-Local-Dev-Setup.md)
- [04 Hosting Web APIs and Workers](docs/modernisation/04-Hosting-WebApis-and-Workers.md)
- [05 Database Migration Strategy](docs/modernisation/05-Database-Migration-Strategy.md)
- [docs/modernisation/06-Release-and-Rollback.md](docs/modernisation/06-Release-and-Rollback.md)
- [docs/modernisation/07-12-to-24-Month-Roadmap.md](docs/modernisation/07-12-to-24-Month-Roadmap.md)

### Patterns
- [docs/patterns/dependency-injection.md](docs/patterns/dependency-injection.md)
- [docs/patterns/configuration-and-secrets.md](docs/patterns/configuration-and-secrets.md)
- [docs/patterns/logging-and-correlation.md](docs/patterns/logging-and-correlation.md)
- [docs/patterns/error-handling-problemdetails.md](docs/patterns/error-handling-problemdetails.md)
- [docs/patterns/data-access-ef-vs-dapper.md](docs/patterns/data-access-ef-vs-dapper.md)
- [docs/patterns/testing-unit-vs-integration.md](docs/patterns/testing-unit-vs-integration.md)
- [docs/patterns/reverse-proxy-gateway.md](docs/patterns/reverse-proxy-gateway.md)

### Tutorials
- [docs/tutorials/VB6-to-CSharp-Tutorial.md](docs/tutorials/VB6-to-CSharp-Tutorial.md)

## 🤝 Contributing
- [CONTRIBUTING.md](CONTRIBUTING.md)

## 📊 Ports & Endpoints Reference
- [docs/ports-and-urls.md](docs/ports-and-urls.md)

## Suggested Reading Order for VB6 Developers
1. [VB6-to-CSharp-Tutorial.md](docs/tutorials/VB6-to-CSharp-Tutorial.md)
2. [Windows-vs-Web-Development.md](docs/foundations/Windows-vs-Web-Development.md)
3. [App-Types-Overview.md](docs/App-Types-Overview.md)
4. [Learning Path README](docs/learning-path/README.md)
5. [Strangler-Fig-Approach.md](docs/modernisation/02-Strangler-Fig-Approach.md)
