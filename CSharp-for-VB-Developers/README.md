# C# for Visual Basic Windows App Developers (Starter Kit)

This repo is a **hands-on orientation** for Visual Basic (VB) Windows app developers moving into **modern C#/.NET**.
It’s structured as a small Visual Studio solution with multiple sample projects—each representing a common “app type”
you’ll see in the C#/.NET world:

- **Windows Desktop (WinForms)** — classic UI apps (similar to many VB apps)
- **Console** — quick utilities, batch jobs, tooling
- **Web App (ASP.NET Core Razor Pages)** — server-rendered web UI
- **Web API (ASP.NET Core Minimal API)** — REST/JSON backend services
- **Cloud-style Worker Service** — background processing (often hosted in containers/Cloud)

It also includes an **optional VB WinForms project** (tiny) to help you compare “same idea, different syntax” *without*
turning the repo into a VB course.

---

## Should you include a VB app?

**Recommendation:** include *one* small VB project **only for the Windows/WinForms scenario**, as a side-by-side
syntax comparison (events, controls, common patterns). For web/web API/cloud, VB comparisons usually add noise:
those app models are already new for many Windows devs, so doubling the code can slow learning.

So this repo includes:

✅ **WinForms in C#** + ✅ **WinForms in VB (comparison)**  
✅ All other app types: **C# only** with comments + README explanations

---

## What’s in the solution?

### `01-WinFormsCSharp` (net8.0-windows)
- Basic form with button click event
- Simple list binding
- Notes on event wiring, `using`, `var`, nullable, etc.

### `01-WinFormsVB` (net8.0-windows) *(optional comparison)*
- Same UI idea as the C# WinForms project
- Keeps things minimal—just enough to compare syntax and event handling

### `02-ConsoleCSharp` (net8.0)
- Shows top-level statements vs `Main`
- A couple of helper methods and string interpolation

### `03-WebApp-RazorPages` (net8.0)
- Razor Pages basics
- A simple “Hello + time” page
- Quick mapping of concepts: pages, handlers, DI

### `04-WebApi-Minimal` (net8.0)
- Minimal API endpoints: GET/POST
- In-memory “todo” list
- Demonstrates DI, logging, model validation-ish basics

### `05-WorkerService` (net8.0)
- Background worker loop
- Logging
- Configuration and dependency injection patterns common in cloud hosting

---

## Prereqs

- **Visual Studio 2022** (recommended) with:
  - **.NET Desktop Development**
  - **ASP.NET and web development**
- Or **.NET 8 SDK** + VS Code

---

## Build & Run (Visual Studio)

1. Open `CSharpForVBDevelopers.sln`
2. Right-click a project → **Set as Startup Project**
3. Press **F5**

---

## Build & Run (CLI)

From the repo root:

```bash
dotnet build
dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj
dotnet run --project src/04-WebApi-Minimal/WebApiMinimal.csproj
dotnet run --project src/03-WebApp-RazorPages/WebAppRazorPages.csproj
dotnet run --project src/05-WorkerService/WorkerService.csproj
```

WinForms projects require Windows:

```bash
dotnet run --project src/01-WinFormsCSharp/WinFormsCSharp.csproj
```

---

## VB → C# quick cheat sheet

See: `docs/VB-to-CSharp-Cheatsheet.md`

---

## Suggested learning path

1. **WinForms (C#)**: focus on syntax differences and events
2. **Console**: get comfortable with C# idioms quickly
3. **Web API**: learn modern service patterns (DI, logging, config)
4. **Web App**: learn server-rendered UI basics
5. **Worker/Cloud**: background processing patterns

---

## Notes

- Target frameworks are **.NET 8** for longevity.
- The projects are intentionally small: they’re meant to be read, stepped through, and modified.

Enjoy—and treat this as a base you can extend for your team.
