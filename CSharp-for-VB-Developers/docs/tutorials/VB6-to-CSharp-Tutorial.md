# VB6 to C# and Modern .NET: A Friendly, Practical Tutorial

If you built real software in VB6, you already know how to solve business problems. That experience is valuable in C# and modern .NET.

This tutorial is here to help you map what you already know to modern tooling and patterns, without pretending your VB6 background is “wrong.” We will move from language differences, to mindset shifts, to practical migration patterns, and close with how to use AI safely while modernizing.

---

## 1) VB6 vs C# language differences (with side-by-side examples)

### 1.1 Variables and types

VB6 allowed lots of implicit behavior (especially with `Variant`). Modern C# favors explicit typing, compile-time checks, and fewer surprises.

#### VB6 style (implicit/defaults can sneak in)

```vb
Dim total        ' Variant by default
total = 10
total = "10"     ' Also allowed (Variant)

Dim count As Integer
count = 5
```

#### C# style (explicit or inferred, but strongly typed)

```csharp
object total = 10;      // object can hold anything, but you must cast/use carefully

int count = 5;

var price = 12.50m;     // inferred at compile time as decimal
// price = "12.50";      // compile-time error
```

**Tip for VB6 developers:** if you feel tempted to use `object` everywhere, pause. Usually you want a specific type (`int`, `decimal`, `string`, custom class, etc.).

---

### 1.2 Strings: concatenation vs interpolation

In VB6 you likely used `&` to concatenate. In C#, concatenation is `+`, but interpolation is cleaner.

#### VB6

```vb
Dim firstName As String
firstName = "Ada"

Dim message As String
message = "Hello " & firstName & ", welcome!"
```

#### C#

```csharp
string firstName = "Ada";

string message1 = "Hello " + firstName + ", welcome!";
string message2 = $"Hello {firstName}, welcome!";   // preferred
```

Interpolation gets even better with formatting:

```csharp
decimal amount = 1234.5m;
string text = $"Total: {amount:C}"; // currency formatting
```

---

### 1.3 Error handling: `On Error GoTo` vs `try/catch`

VB6 relied on flow-control style error handling. C# uses exceptions with structured blocks.

#### VB6

```vb
On Error GoTo HandleError

Dim x As Integer
x = 10 / 0

Exit Sub

HandleError:
    MsgBox "Error: " & Err.Description
```

#### C#

```csharp
try
{
    int x = 10 / 0;
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Unexpected error: {ex.Message}");
}
finally
{
    Console.WriteLine("Always runs (cleanup)");
}
```

**Migration advice:** catch specific exceptions first; avoid blanket `catch` unless you rethrow or log meaningfully.

---

### 1.4 Collections: `Collection`/Array vs `List<T>` and `Dictionary<TKey,TValue>`

VB6 collections often held mixed types. C# generics enforce type safety.

#### VB6

```vb
Dim names(2) As String
names(0) = "A"
names(1) = "B"

Dim items As New Collection
items.Add "Apple"
items.Add 42
```

#### C#

```csharp
string[] names = { "A", "B" };

var items = new List<string>();
items.Add("Apple");
// items.Add(42); // compile-time error

var lookup = new Dictionary<string, int>();
lookup["Alice"] = 100;
lookup["Bob"] = 200;
```

Lookup example:

```csharp
if (lookup.TryGetValue("Alice", out int score))
{
    Console.WriteLine(score);
}
```

---

### 1.5 Classes, modules, forms, visibility, default properties

VB6 had class modules, standard modules, and forms with implicit/default behavior. C# is more explicit.

#### VB6 class/module style

```vb
' Standard module
Public Sub LogMessage(msg As String)
    Debug.Print msg
End Sub

' Class module
Private m_Name As String

Public Property Get Name() As String
    Name = m_Name
End Property

Public Property Let Name(value As String)
    m_Name = value
End Property
```

#### C# equivalent concepts

```csharp
public static class Logger
{
    public static void LogMessage(string message)
    {
        Console.WriteLine(message);
    }
}

public class Customer
{
    public string Name { get; set; } = string.Empty;
}
```

Visibility mapping (roughly):

- VB6 `Public` → C# `public`
- VB6 `Private` → C# `private`
- VB6 `Friend` → C# `internal`

**Default properties:** VB6 often used them implicitly; C# generally avoids that style to keep calls obvious and readable.

---

### 1.6 Events: `WithEvents` + `Handles` vs C# event subscription

#### VB6-ish pattern

```vb
Private WithEvents btnSave As CommandButton

Private Sub btnSave_Click()
    MsgBox "Saved"
End Sub
```

#### C# WinForms-style subscription

```csharp
public MainForm()
{
    InitializeComponent();
    btnSave.Click += BtnSave_Click;
}

private void BtnSave_Click(object? sender, EventArgs e)
{
    MessageBox.Show("Saved");
}
```

In C#, you explicitly subscribe (`+=`) and can unsubscribe (`-=`).

---

### 1.7 Date/Time types and common pitfalls

VB6 used `Date`; .NET offers `DateTime`, `DateTimeOffset`, `TimeSpan`, etc.

```csharp
DateTime localNow = DateTime.Now;          // local time
DateTime utcNow = DateTime.UtcNow;         // UTC
DateOnly date = DateOnly.FromDateTime(DateTime.Now); // .NET 6+
```

Common pitfalls:

1. Mixing local and UTC values.
2. Parsing dates with culture assumptions.
3. Storing local time in databases without timezone context.

Safer parse example:

```csharp
using System.Globalization;

string input = "2026-02-15";
DateTime parsed = DateTime.ParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture);
```

---

### 1.8 `Nothing`/`null` and nullable reference types

VB6/VB.NET used `Nothing`; C# uses `null`. Modern C# adds nullable reference type checks.

```csharp
#nullable enable

string name = "Ada";
string? maybeName = null;

if (maybeName is not null)
{
    Console.WriteLine(maybeName.Length);
}
```

Benefits:

- Warnings when you might dereference null.
- More self-documenting code (`string` vs `string?`).

---

### 1.9 COM and interop basics (high-level)

Many VB6 apps depended on COM DLLs/OCXs. In .NET you can:

1. Keep COM components and call them through interop.
2. Wrap COM access in a small adapter class.
3. Slowly replace COM-backed functionality with pure .NET implementations.

High-level C# shape:

```csharp
public interface ILegacyCalculator
{
    decimal CalculateTotal(decimal amount);
}

public sealed class ComLegacyCalculatorAdapter : ILegacyCalculator
{
    public decimal CalculateTotal(decimal amount)
    {
        // Call COM object here (interop boundary)
        return amount; // placeholder
    }
}
```

The key idea: keep COM access isolated so the rest of your app remains modern and testable.

---

### 1.10 File I/O and path handling

VB6 often used older file APIs and string-built paths. In .NET, use `System.IO` and `Path.Combine`.

#### VB6

```vb
Open "C:\temp\notes.txt" For Output As #1
Print #1, "Hello"
Close #1
```

#### C#

```csharp
string folder = Path.Combine("C:", "temp");
string file = Path.Combine(folder, "notes.txt");

Directory.CreateDirectory(folder);
File.WriteAllText(file, "Hello");

string text = File.ReadAllText(file);
```

Use `Path.Combine` instead of manually concatenating path separators.

---

## 2) VB6 mindset shifts

### 2.1 Stateful desktop UI vs stateless web request model (brief)

In VB6 forms, your UI and state lived together for long sessions. In web apps, each request is usually independent (stateless by default).

- Desktop mindset: “Form is alive; keep fields in memory.”
- Web mindset: “Each request may come to any server instance; persist required state externally (DB/cache/session/token).”

This is one of the biggest conceptual shifts when moving to ASP.NET Core.

### 2.2 Separation of concerns and layering

VB6 code often mixed UI + business + data access in one form/module. Modern .NET works better with clear layers:

- **Presentation**: WinForms/WPF/Web/API endpoints
- **Business logic**: rules and workflows
- **Data access**: database and external systems

Benefits:

- Easier testing
- Easier onboarding
- Safer refactoring

### 2.3 Dependency injection without jargon

Think of DI as: **“Pass required helpers into a class instead of creating them inside that class.”**

Without DI style:

```csharp
public class OrderService
{
    private readonly EmailSender _email = new EmailSender();
}
```

With DI style:

```csharp
public class OrderService
{
    private readonly IEmailSender _email;

    public OrderService(IEmailSender email)
    {
        _email = email;
    }
}
```

Why this helps:

- Swap real implementations for test fakes.
- Reduce hard-coded dependencies.
- Keep classes focused.

---

## 3) Practical porting patterns

### 3.1 Wrap old logic behind interfaces

Start by defining *what* the code should do, not *how* legacy code does it.

```csharp
public interface IInvoiceCalculator
{
    decimal CalculateTotal(decimal subtotal, decimal taxRate);
}
```

Then provide one adapter for old logic and one modern implementation:

```csharp
public sealed class LegacyInvoiceCalculatorAdapter : IInvoiceCalculator
{
    public decimal CalculateTotal(decimal subtotal, decimal taxRate)
    {
        // route to legacy VB6/COM logic
        return subtotal + (subtotal * taxRate);
    }
}

public sealed class ModernInvoiceCalculator : IInvoiceCalculator
{
    public decimal CalculateTotal(decimal subtotal, decimal taxRate)
    {
        return subtotal + (subtotal * taxRate);
    }
}
```

Your app depends on `IInvoiceCalculator`, so swapping implementations is safe.

### 3.2 Build a compatibility layer

A compatibility layer can normalize old assumptions:

- String date formats
- Error codes to exceptions
- 1-based indexing assumptions
- Sentinel values (`-1`, empty string, etc.)

Example shape:

```csharp
public interface ILegacyCustomerGateway
{
    CustomerDto GetByCode(string code);
}

public sealed class LegacyCustomerGateway : ILegacyCustomerGateway
{
    public CustomerDto GetByCode(string code)
    {
        // talk to COM/old DB schema/old API
        // map legacy result into modern DTO
        return new CustomerDto(code, "Unknown");
    }
}

public sealed record CustomerDto(string Code, string Name);
```

Keep this layer small and explicit; treat it as a boundary, not your future architecture.

### 3.3 Where to start converting code

A practical order that works well:

1. **Identify stable business rules first** (pricing, validation, calculations).
2. **Write characterization tests** against current behavior.
3. **Extract interfaces around legacy dependencies** (COM, DB access, file formats).
4. **Replace one seam at a time** (strangler pattern).
5. **Migrate UI last or in parallel**, depending on business pressure.

Avoid starting with the biggest form just because it is visible; start where risk is manageable and value is clear.

---

## 4) Using AI tools to learn and migrate safely

AI can accelerate learning and migration, but it must be used with review and verification.

### 4.1 How to ask good questions/prompts

Good prompts include context, constraints, and expected output format.

Weak prompt:

```text
Convert this VB6 code to C#.
```

Better prompt:

```text
Convert this VB6 function to C# .NET 8.
Constraints:
- Keep behavior identical, including rounding rules.
- Use decimal for money.
- Add 3 xUnit tests for edge cases.
- Explain any assumptions.
VB6 code:
...paste snippet...
```

Another useful prompt:

```text
I am a VB6 developer. Explain this C# compiler error in VB6 terms and show a minimal before/after fix.
Error:
...error text...
```

### 4.2 How to verify AI output

Always verify with engineering discipline:

1. **Compile** the code.
2. **Run** key flows.
3. **Test** behavior (unit/integration tests).
4. **Compare** outputs against old system behavior.
5. **Review** for security and performance concerns.

A useful habit: keep “golden” input/output cases from production and compare old vs new results.

### 4.3 What NOT to paste into AI (and safer alternatives)

Do **not** paste:

- Secrets (API keys, passwords, connection strings)
- Customer personal data
- Proprietary source code you are not allowed to share
- Internal architecture documents marked confidential

Safer alternatives:

- Replace sensitive identifiers with placeholders.
- Share minimal reproducible snippets, not full modules.
- Use synthetic or anonymized data.
- Keep private code in approved enterprise AI tooling only.

### 4.4 Great AI use cases during migration

Use AI for:

- **Syntax translation** (VB6/VB.NET idioms to C#)
- **Refactoring suggestions** (extract methods, split responsibilities)
- **Generating tests** from existing behavior
- **Explaining error messages** in plain language

Final rule: **AI assists, but you own correctness.**

---

## 5) Mini glossary (modern terms you will hear often)

- **NuGet**: Package manager for .NET libraries.
- **SDK-style project**: Modern `.csproj` format with simpler configuration and implicit conventions.
- **DI (Dependency Injection)**: Passing dependencies into classes rather than constructing everything internally.
- **Middleware**: Components in ASP.NET Core request pipeline (logging, auth, error handling, etc.).
- **DTO (Data Transfer Object)**: Lightweight object used to move data across boundaries (API requests/responses).
- **ORM (Object-Relational Mapper)**: Maps objects to database tables (e.g., EF Core).
- **Migrations**: Versioned schema changes for databases.
- **CI/CD**: Automated build/test/deploy pipelines.

---

## 6) Suggested learning path from this point

1. Read this tutorial once end-to-end.
2. Port one small VB6 module (pure business logic) to C#.
3. Add tests that pin behavior before refactoring.
4. Introduce interfaces at legacy boundaries.
5. Move one endpoint/screen at a time.
6. Keep release cycles small and measurable.

You are not “starting over.” You are upgrading your delivery toolbox while keeping your domain knowledge intact.
