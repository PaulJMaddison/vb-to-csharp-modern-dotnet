# 02 - C# Quick Wins

Goal: build confidence with high-value C# syntax by making tiny safe edits in existing projects.

> Complete these exercises in a feature branch. Revert after learning if you want to keep baseline code unchanged.

## Exercise 2.1 - Nullable reference types

**Goal**
- Understand `string` vs `string?` and avoid null reference bugs.

**Prerequisites**
- Module 01 complete.

**Steps**
1. Open `src/04-WebApi-Minimal/Program.cs`.
2. Find `public record UpdateTodo(string? Title, bool? IsDone);`.
3. Add a temporary endpoint under existing mappings:

```csharp
app.MapGet("/api/null-demo", (string? value) =>
{
    var message = value?.Trim() ?? "(null or empty)";
    return Results.Ok(new { message });
});
```

4. Build project:

```bash
dotnet build src/04-WebApi-Minimal/WebApiMinimal.csproj
```

**Expected outcome**
- You can call `/api/null-demo` with or without query value and avoid exceptions.

**Verification**

```bash
curl "http://localhost:63759/api/null-demo"
curl "http://localhost:63759/api/null-demo?value= hello "
```

**VB6 mapping**
- Similar intention as handling `Nothing`/empty checks, but compiler now helps you reason about null upfront.

**Common pitfalls**
- Treating nullable and non-nullable as same type.
- Forgetting `?.` and `??` operators.

**Stretch goals**
- Enable nullable warnings as errors in one project and fix warnings.

---

## Exercise 2.2 - String interpolation

**Goal**
- Replace concatenation with readable interpolation.

**Prerequisites**
- Module 01 complete.

**Steps**
1. Open `src/02-ConsoleCSharp/Program.cs`.
2. Find one string concatenation line.
3. Convert it to interpolation format `$"...{value}..."`.
4. Run:

```bash
dotnet run --project src/02-ConsoleCSharp/ConsoleCSharp.csproj
```

**Expected outcome**
- Output is unchanged but formatting code is easier to read.

**Verification**
- Compare before/after console output.

**VB6 mapping**
- Instead of repeated `"Hello " & name & "..."`, interpolation puts expression placeholders in one template.

**Common pitfalls**
- Missing `$` prefix before string.
- Not escaping braces when needed (`{{` and `}}`).

**Stretch goals**
- Add format specifiers: `$"{DateTime.Now:yyyy-MM-dd HH:mm}"`.

---

## Exercise 2.3 - Records vs classes

**Goal**
- Understand immutable data carriers (`record`) versus mutable objects (`class`).

**Prerequisites**
- Module 01 complete.

**Steps**
1. Open `src/04-WebApi-Minimal/Program.cs`.
2. Locate existing record types (`TodoItem`, `CreateTodo`, `UpdateTodo`).
3. Add a temporary class near the bottom:

```csharp
public class LegacyTodo
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
}
```

4. Add a temporary endpoint:

```csharp
app.MapGet("/api/record-vs-class", () =>
{
    var r1 = new TodoItem(1, "A", false);
    var r2 = r1 with { Title = "B" };

    var c1 = new LegacyTodo { Id = 1, Title = "A" };
    var c2 = c1;
    c2.Title = "B";

    return Results.Ok(new { recordOriginal = r1.Title, recordCopy = r2.Title, classOriginal = c1.Title });
});
```

5. Run API and call endpoint.

**Expected outcome**
- Record copy does not mutate original; class reference assignment does.

**Verification**

```bash
curl "http://localhost:63759/api/record-vs-class"
```

**VB6 mapping**
- Record + `with` behaves like “copy and modify” in one statement.
- Class reference behavior is closer to object reference semantics you already know.

**Common pitfalls**
- Assuming `=` or assignment clones objects.
- Using mutable classes for DTO-style payloads when records would be clearer.

**Stretch goals**
- Convert one DTO in a sample project from class to record and rerun tests.

---

## Exercise 2.4 - LINQ basics

**Goal**
- Use LINQ for filtering/sorting in expressive pipeline style.

**Prerequisites**
- Module 01 complete.

**Steps**
1. Open `src/11-WebApi-CleanArchitecture/Program.cs`.
2. Find `/api/customers` endpoint that maps customer list to DTOs.
3. Add temporary ordering and filter by query parameter:

```csharp
app.MapGet("/api/customers/search", async (string? startsWith, CustomerService service, CancellationToken ct) =>
{
    var customers = await service.GetCustomersAsync(ct);
    var query = customers.AsEnumerable();

    if (!string.IsNullOrWhiteSpace(startsWith))
        query = query.Where(c => c.Name.StartsWith(startsWith, StringComparison.OrdinalIgnoreCase));

    var result = query
        .OrderBy(c => c.Name)
        .Select(c => new CustomerDto(c.Id, c.Name, c.Email));

    return Results.Ok(result);
});
```

4. Build and run clean API.

**Expected outcome**
- Endpoint returns filtered, ordered list.

**Verification**

```bash
curl "http://localhost:5111/api/customers/search"
curl "http://localhost:5111/api/customers/search?startsWith=A"
```

**VB6 mapping**
- LINQ is similar to a readable in-memory query pipeline instead of manual loops with condition flags.

**Common pitfalls**
- Forgetting LINQ queries are often deferred until enumerated.
- Mixing `IQueryable` and `IEnumerable` expectations.

**Stretch goals**
- Add paging (`Skip`, `Take`) with query parameters.

---

## Quick wins completion checklist

- [ ] 2.1 Nullable demo endpoint works
- [ ] 2.2 Interpolation update runs
- [ ] 2.3 Record vs class demo verified
- [ ] 2.4 LINQ search endpoint verified
