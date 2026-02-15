# VB → C# Cheatsheet (for Windows App Devs)

This is a **practical** mapping focused on what you’ll hit moving from VB WinForms/WPF-ish patterns into C#.

## Syntax / Language

### Comments
- VB: `' comment`
- C#: `// comment` and `/* block */`

### Imports / Using
- VB: `Imports System`
- C#: `using System;`

### Variables
- VB: `Dim x As Integer = 5`
- C#: `int x = 5;`  
  Also common: `var x = 5;` (type inferred)

### Properties
- VB:
  ```vb
  Public Property Name As String
  ```
- C#:
  ```csharp
  public string Name { get; set; }
  ```

### String interpolation
- VB: `$"Hello {name}"`
- C#: `$"Hello {name}"`

### If
- VB:
  ```vb
  If x > 0 Then
      ...
  Else
      ...
  End If
  ```
- C#:
  ```csharp
  if (x > 0)
  {
      ...
  }
  else
  {
      ...
  }
  ```

### Select Case / switch
- VB: `Select Case`
- C#: `switch` (or modern `switch` expressions)

### Null / Nothing
- VB: `Nothing`
- C#: `null`

### Events
- VB: `Handles Button1.Click`
- C#: `button1.Click += (s, e) => { ... };`  
  or `button1.Click += Button1_Click;`

---

## Modern .NET concepts you’ll see everywhere (Web/API/Cloud)

### Dependency Injection (DI)
In ASP.NET Core and Worker Services, you typically *register* services and *inject* them into constructors.

### Configuration
App settings are usually read from `appsettings.json` and environment variables.

### Logging
Standardized logging is built in (often `ILogger<T>`).

---

## App types overview (what to use when)

- **WinForms/WPF (Windows desktop):** classic installed UI apps
- **Console:** utilities, scripts, build tools, batch tasks
- **Web App (ASP.NET Core):** server-rendered UI or SPA hosts
- **Web API:** backend services for web/mobile/desktop clients
- **Worker Service / Cloud:** background processing, scheduled jobs, queues

