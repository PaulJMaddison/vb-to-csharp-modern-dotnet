# 08 - Web UI Lab

Goal: use three UI models as a reference/refresher and align team standards for existing MVC/Blazor knowledge.

Mini-labs (reference + refresher):

1. Razor Pages
2. MVC
3. Blazor

## Prerequisites

- Modules 01-07 complete.
- Browser available.

---

## Mini-lab A - Razor Pages form + handler

Project: `src/03-WebApp-RazorPages`.

**What it's for**
- Server-rendered forms with simple page-centric patterns.

**How it differs from WinForms**
- Events are HTTP request handlers (`OnGet`, `OnPost`) instead of long-lived form event loop.
- State is reloaded per request unless persisted.

**Goal**
- Add one extra input and handle it in `OnPost`.

**Steps**
1. Edit `src/03-WebApp-RazorPages/Pages/Index.cshtml` and add a second input field (`category`).
2. Edit `src/03-WebApp-RazorPages/Pages/Index.cshtml.cs`:
   - update `OnPost` signature to accept `message` and `category` from form.
   - update `Message` output text with both values.
3. Run:

```bash
dotnet run --project src/03-WebApp-RazorPages/WebAppRazorPages.csproj
```

4. Submit form in browser.

**Expected outcome**
- Page updates message based on posted values.

**Verification**
- Submitted values appear in rendered HTML.

**Where state lives**
- In the server-side `PageModel` during request; not persistent unless saved elsewhere.

**Common pitfalls**
- Expecting field values to stay forever without storage/session.

**Stretch goal**
- Add validation summary when fields are empty.

---

## Mini-lab B - MVC controller/action/view

Project: `src/07-MvcWebApp`.

**What it's for**
- Teams that prefer explicit controller + view separation.

**How it differs from WinForms**
- Controller builds model; view renders HTML. No direct UI control object manipulation.

**Goal**
- Add a new action/view pair showing a personalized greeting.

**Steps**
1. Edit `src/07-MvcWebApp/Controllers/HelloController.cs`.
2. Add route action:

```csharp
[HttpGet("hello/{name}")]
public IActionResult ByName(string name)
{
    var model = new GreetingModel { Message = $"Hello, {name}!" };
    ViewData["CurrentTime"] = DateTime.Now;
    return View("Index", model);
}
```

3. Run:

```bash
dotnet run --project src/07-MvcWebApp/MvcWebApp.csproj
```

4. Browse to `/hello/Ada`.

**Expected outcome**
- MVC page renders personalized message.

**Verification**
- URL parameter is reflected in greeting text.

**Where state lives**
- Request model + route data + optional temp/session stores.

**Common pitfalls**
- Putting business logic into view file.

**Stretch goal**
- Create a dedicated `ByName.cshtml` view.

---

## Mini-lab C - Blazor component + click + binding

Project: `src/06-BlazorWebApp`.

**What it's for**
- Interactive C# UI components in browser.

**How it differs from WinForms**
- UI still event-driven, but rendered as web DOM through components.

**Goal**
- Add an input field and bind it to component state.

**Steps**
1. Edit `src/06-BlazorWebApp/Components/Pages/Counter.razor`.
2. Add textbox with two-way binding and display text:

```razor
<input @bind="name" placeholder="Enter your name" />
<p>Hello @name</p>
```

3. In `@code` block, add:

```csharp
private string name = "Learner";
```

4. Run:

```bash
dotnet run --project src/06-BlazorWebApp/BlazorWebApp.csproj
```

5. Open `/counter` and test click + typed name.

**Expected outcome**
- Counter still increments; greeting updates as you type.

**Verification**
- No page reload needed for UI updates.

**Where state lives**
- Component fields (`@code`) for current circuit/session.

**Common pitfalls**
- Expecting `@bind` changes to persist after app restart/navigation without storage.

**Stretch goal**
- Add simple form submit button and clear behavior.

---

## Lab checklist

- [ ] Razor Pages form enhancement completed
- [ ] MVC route/action enhancement completed
- [ ] Blazor binding enhancement completed
