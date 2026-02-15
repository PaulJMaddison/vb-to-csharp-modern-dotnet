# Windows vs Web Development (for VB6/VB WinForms Developers)

If you built VB6 or WinForms apps for years, you already understand event-driven development, UI state, and business logic flow.

What changes on the web is **where state lives**, **how execution is triggered**, and **how many users hit the same code at once**.

This guide explains the mental model shift in practical terms.

---

## 1) The fundamental difference: stateful desktop vs stateless web

### Windows desktop apps (VB6/WinForms): stateful, long-lived process

In a desktop app:

- Your EXE starts and keeps running.
- Forms stay alive in memory.
- Control values remain available until closed or changed.
- Module-level/global variables stay in process and are easy to reference.
- Button click code runs against in-memory objects you already have.

In short: **your app keeps context by default**.

### Web apps: stateless per HTTP request

On the web:

- The browser sends an HTTP request.
- The server handles it and returns a response.
- That request is over.
- The next request might hit a different server process (or even another machine).

In short: **context is lost between requests unless you store it explicitly**.

> [!IMPORTANT]
> In desktop, state is "naturally present." In web, state is a deliberate design choice.

---

## 2) VB6 concept mapping to web equivalents

### Form events (`Form_Load`, `CommandButton_Click`) → HTTP handlers/endpoints

**VB6 thinking:** "When form loads, initialize controls. When button clicks, run code."

**Web equivalent:**

- Initial page load usually maps to `GET`.
- Form submit/API command usually maps to `POST`.
- Update operations often use `PUT/PATCH`.
- Delete operations use `DELETE`.

Instead of an always-running form object, you define endpoint handlers that run per request.

### Controls/properties → HTML + CSS + DOM + (optional) server rendering

In desktop:

- You set `TextBox.Text`, `Label.Caption`, etc. directly.

On web:

- UI markup is HTML.
- Presentation is CSS.
- Browser runtime object model is DOM.
- Server frameworks (Razor Pages/MVC/Blazor Server) may render HTML for you.

You no longer own a single in-memory control tree per user in the same way a WinForms process does.

### Session state → cookies/session stores (with tradeoffs)

Web frameworks can track per-user session data by storing a session key in a cookie and placing data in server storage.

Tradeoffs:

- Easy for temporary per-user data.
- Can break horizontal scaling if tied to one server.
- Needs timeout/expiration strategy.
- Should not store large objects.

### Global variables → per-request services + carefully managed shared caches

Desktop globals are often convenient, but in web:

- Per-request data should live in request scope (parameters, scoped services, claims, etc.).
- Shared app-wide data should be immutable, thread-safe, or externalized.
- Caches can help performance, but require expiration and concurrency strategy.

> [!WARNING]
> A mutable global object that was "fine" in desktop can become a race-condition hotspot in a web app.

---

## 3) HTTP basics in VB6-friendly terms

Think of HTTP as a strict message protocol:

- Client sends request message.
- Server sends response message.
- No implicit long-term memory between messages.

### Request/response lifecycle

Typical flow:

1. Browser/app sends URL + method + headers (+ optional body).
2. Server routing picks a handler.
3. Handler executes business/data logic.
4. Server sends status code + headers + body.
5. Client renders result or processes JSON.

### Headers and status codes

Headers carry metadata (content type, auth token, caching hints, etc.).

Status code families:

- `2xx`: success (`200 OK`, `201 Created`)
- `4xx`: client issue (`400 Bad Request`, `401 Unauthorized`, `404 Not Found`)
- `5xx`: server issue (`500 Internal Server Error`)

### GET vs POST vs PUT vs DELETE

- `GET`: read data, should not mutate state.
- `POST`: create or execute command-like action.
- `PUT`: replace/update a resource (idempotent by convention).
- `DELETE`: remove a resource.

If you used to think "button click runs save code," now think "client sends POST/PUT request to a save endpoint."

---

## 4) What “events” mean on the web

### Server-side events are not WinForms events

In WinForms, event handlers are attached to live control instances.

In web apps, server code runs when a request arrives. It does not continuously receive UI events from an always-live form object.

### UI events happen in the browser

Clicks, keypresses, and input-change events occur in browser JavaScript runtime (or abstractions on top of it).

If server logic is needed, browser code sends another HTTP request (full page post, AJAX/fetch call, WebSocket message, etc.).

### What “postback” means

Historically (e.g., Web Forms), postback meant submitting page data back to server, re-running server lifecycle, and re-rendering page.

Modern approaches:

- Traditional server rendering: form submits and returns new HTML.
- AJAX/fetch: partial async calls for JSON or fragments.
- SPA/component models: richer client-side state with API calls.
- Blazor: component/event model in C# (Server/WebAssembly), still fundamentally different from WinForms process lifetime.

---

## 5) Tiny side-by-side examples

### A) WinForms button click vs Web API POST

**WinForms (local event handler):**

```csharp
private void btnSave_Click(object sender, EventArgs e)
{
    var name = txtName.Text;
    _customerService.Save(name);
    lblStatus.Text = "Saved";
}
```

**Web API (HTTP endpoint):**

```csharp
app.MapPost("/customers", (CreateCustomerRequest req, ICustomerService service) =>
{
    service.Save(req.Name);
    return Results.Created($"/customers/{req.Name}", null);
});
```

Key shift: no direct `lblStatus.Text` on server for a specific user's live window; server returns a response and the client updates UI.

### B) Razor Pages form submit vs MVC action

**Razor Pages PageModel:**

```csharp
public class EditModel : PageModel
{
    [BindProperty] public string Name { get; set; } = "";

    public void OnGet() { }

    public IActionResult OnPost()
    {
        // Save Name
        return RedirectToPage("Success");
    }
}
```

**MVC controller action:**

```csharp
public class CustomersController : Controller
{
    [HttpPost]
    public IActionResult Edit(EditCustomerVm vm)
    {
        // Save vm.Name
        return RedirectToAction("Details", new { id = vm.Id });
    }
}
```

Both handle `POST`, but they organize code differently.

### C) Blazor button click and how it differs from WinForms

```razor
<button @onclick="Increment">Count: @count</button>

@code {
    private int count;
    private void Increment() => count++;
}
```

Looks event-driven like WinForms, but:

- UI is a web component rendered for browser.
- Lifecycle and transport differ by hosting model (Server/WebAssembly).
- Scaling, latency, and connection concerns are web concerns, not desktop process concerns.

---

## 6) State management options and tradeoffs

### Server-side session

Use for short-lived per-user data.

**Pros**

- Easy mental model for migrating teams.
- Keeps sensitive values off client (except session id).

**Cons**

- Memory/storage pressure at scale.
- Sticky session/distributed session complexity.
- Harder to reason about in multi-instance deployments.

### Client-side state (cookies, localStorage, sessionStorage)

**Pros**

- Reduces server memory usage.
- Good for preferences and non-sensitive UI state.

**Cons / security warnings**

- Cookies are sent on requests and can be intercepted if not protected.
- localStorage is accessible to JavaScript; XSS makes it risky for secrets.
- Never store raw credentials or high-value secrets client-side.
- Validate and authorize on server regardless of client state.

### Database-backed state

Persist durable workflow/business state in DB.

Use when data must survive restarts, deployments, and scale-out.

### Distributed cache (e.g., Redis conceptually)

Use for shared, fast-access ephemeral state across instances.

Typical uses:

- Session backing store
- Cached lookups
- Rate-limit counters

Design for cache misses/expirations; cache is a performance layer, not primary truth.

---

## 7) Practical gotchas VB6 developers often hit

### Concurrency: many requests run simultaneously

Desktop app: one user, one process context.

Web app: hundreds/thousands of concurrent requests can hit the same code paths.

### Thread safety matters

Anything shared across requests must be thread-safe.

Watch for:

- Mutable static/global collections
- Non-thread-safe singletons
- Reusing context objects incorrectly across requests

### Long-running work

Do not hold HTTP requests for long background tasks when avoidable.

Prefer:

- Queue + worker service
- Background processing pipeline
- Immediate `202 Accepted` style response when appropriate

### Deployment is not "copy EXE to server"

Web deployment usually includes:

- Build/publish pipeline
- Environment-specific config/secrets
- Reverse proxy / load balancer
- Observability (logs/metrics/traces)
- Zero-downtime or rolling deployment considerations

---

## 8) How to think about debugging in web systems

### Logs over local UI stepping

In desktop, stepping from button click through code is often enough.

In web, issues may involve multiple requests/services/instances. Structured logging becomes primary.

### Correlation IDs

Use a correlation ID per request chain so related logs can be grouped across components.

Without correlation IDs, distributed debugging becomes guesswork.

### Reproducing issues

Capture:

- Exact request method/path
- Headers (especially auth/content type)
- Payload/body
- Response code/body
- Timestamp and correlation ID

Then replay with tools (browser dev tools, curl, Postman, integration tests).

> [!TIP]
> In web debugging, the question is often not "what line fired?" but "which request path and environment conditions produced this behavior?"

---

## Practical mental model to carry forward

When moving from VB6/WinForms to web, use this checklist:

- What is the request boundary?
- Where is state stored between requests?
- Is this data per-user, per-request, or app-wide?
- Is shared data thread-safe?
- What happens under concurrent load?
- How will I observe/debug this in production?

If you internalize those questions, your existing design instincts transfer very well.
