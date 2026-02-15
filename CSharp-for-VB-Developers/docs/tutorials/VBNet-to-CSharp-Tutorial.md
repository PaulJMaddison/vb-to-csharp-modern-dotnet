# VB.NET to C# and Modern .NET: Practical Tutorial

This tutorial is for teams with existing **VB.NET applications on .NET Framework 4.5+** who are moving to modern C# and .NET 8.

---

## 1) VB.NET -> C# language differences that matter in real projects

### Imports vs using

VB.NET:

```vbnet
Imports System
Imports System.Collections.Generic
```

C#:

```csharp
using System;
using System.Collections.Generic;
```

---

### Handles / WithEvents vs event subscription (`+=`)

VB.NET:

```vbnet
Public Class MainForm
    Private WithEvents _service As New OrderService()

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        ' save
    End Sub

    Private Sub _service_OrderSaved(sender As Object, e As EventArgs) Handles _service.OrderSaved
        MessageBox.Show("Saved")
    End Sub
End Class
```

C#:

```csharp
public partial class MainForm : Form
{
    private readonly OrderService _service = new();

    public MainForm()
    {
        InitializeComponent();
        BtnSave.Click += BtnSave_Click;
        _service.OrderSaved += Service_OrderSaved;
    }

    private void BtnSave_Click(object? sender, EventArgs e)
    {
        // save
    }

    private void Service_OrderSaved(object? sender, EventArgs e)
    {
        MessageBox.Show("Saved");
    }
}
```

---

### Default properties

VB.NET can use default properties (for example indexers) with less explicit syntax. In C#, indexers/properties are explicit by design.

VB.NET:

```vbnet
Dim name = customer("DisplayName")
```

C#:

```csharp
var name = customer["DisplayName"];
```

Prefer explicit member access during migration to avoid hidden behavior.

---

### Option Strict / Option Infer and C# equivalents

- `Option Strict On` maps to C#'s compile-time type safety culture (no late-bound calls by default).
- `Option Infer On` maps to `var` local inference in C#.
- Keep conversions explicit (`CInt`, `CDbl` in VB.NET -> `Convert.ToInt32`, casts, or `TryParse` patterns in C#).

---

### Structured error handling (`Try/Catch`) vs legacy `On Error`

If older VB code still uses `On Error Resume Next`, treat it as technical debt and replace with structured handling.

VB.NET preferred:

```vbnet
Try
    SaveOrder(order)
Catch ex As SqlException
    _logger.LogError(ex, "Failed to save order")
End Try
```

C#:

```csharp
try
{
    SaveOrder(order);
}
catch (SqlException ex)
{
    logger.LogError(ex, "Failed to save order");
}
```

---

### Generics: `List(Of T)` vs `List<T>`

VB.NET:

```vbnet
Dim customers As New List(Of Customer)()
customers.Add(New Customer With {.Name = "Ada"})
```

C#:

```csharp
var customers = new List<Customer>();
customers.Add(new Customer { Name = "Ada" });
```

---

### Async/Await (critical for modern services)

VB.NET:

```vbnet
Public Async Function LoadCustomerAsync(id As Integer) As Task(Of Customer)
    Return Await _repo.GetByIdAsync(id)
End Function
```

C#:

```csharp
public async Task<Customer> LoadCustomerAsync(int id)
{
    return await _repo.GetByIdAsync(id);
}
```

Use `async/await` end-to-end for I/O paths (API, DB, HTTP).

---

### LINQ query syntax

VB.NET:

```vbnet
Dim active = From c In customers
             Where c.IsActive
             Order By c.Name
             Select c
```

C# (query syntax):

```csharp
var active = from c in customers
             where c.IsActive
             orderby c.Name
             select c;
```

C# (method syntax used more often in codebases):

```csharp
var active = customers
    .Where(c => c.IsActive)
    .OrderBy(c => c.Name)
    .ToList();
```

---

### Nullable reference types in C#

C# 8+ adds nullable reference types to catch null issues at compile time.

```csharp
string requiredName = "ok";
string? optionalNickname = null;
```

When migrating from VB.NET/.NET Framework, enabling nullable context is a high-value safety upgrade.

---

## 2) .NET Framework -> .NET 8 upgrade basics

### What commonly breaks

- APIs tied to `System.Web` (HttpContext, HttpApplication, Global.asax pipeline).
- Legacy configuration assumptions (`web.config` only, machine-level config dependencies).
- Windows-specific dependencies (COM interop, registry assumptions, GAC-installed components).
- Old authentication modules tightly coupled to IIS/classic hosting.

### Windows-only considerations

- Keep WinForms/WPF workloads on Windows targets.
- For cross-platform services, isolate Windows-specific code behind interfaces.
- Validate third-party libraries for .NET 8 compatibility early.

### Practical migration path

1. Stabilize on .NET Framework 4.8 where possible (from 4.5+ baseline).
2. Extract business logic from UI/event code into class libraries.
3. Introduce API boundaries and gateway routing (strangler pattern).
4. Multi-target shared libraries when useful (`net48` + `net8.0`).
5. Move service-by-service to .NET 8, keeping database contracts stable initially.

Example multi-targeting in a shared library:

```xml
<TargetFrameworks>net48;net8.0</TargetFrameworks>
```

---

## 3) Suggested first wins for VB.NET teams

1. Convert one VB.NET business module to C# with unit tests.
2. Add DI + configuration + logging standards to one API.
3. Put one legacy capability behind the gateway.
4. Keep DB schema changes minimal in phase 1; focus on delivery safety.

Use this tutorial with:
- `docs/VB-to-CSharp-Cheatsheet.md`
- `docs/modernisation/*`
- `docs/learning-path/*`
