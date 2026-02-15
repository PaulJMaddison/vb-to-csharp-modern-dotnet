# C#/.NET Application Types (VB Windows Developer View)

Use this as a decision guide when moving from VB.NET/VB desktop habits to modern .NET architecture.

## Windows Desktop

### WinForms
- **Closest transition path** from VB WinForms: event handlers, forms, controls, designer workflow.
- **Choose when** your app is mostly internal, desktop-centric, and you need to move quickly.
- **Strengths**: Fast delivery, familiar mental model, large ecosystem of existing patterns.
- **Tradeoffs**: Harder to create highly modern/responsive UI compared to newer UI stacks.

### WPF
- **XAML + MVVM desktop framework** with richer UI composition than WinForms.
- **Choose when** you need complex data binding, advanced styling, templating, or long-lived desktop architecture.
- **Strengths**: Clean UI separation (View + ViewModel), scalable design for large client apps.
- **Tradeoffs**: Steeper learning curve (XAML, binding/debugging, MVVM discipline).

## Web UI App Types

### Razor Pages
- **Page-focused model**: each page has a `.cshtml` file + `PageModel` code-behind style.
- **Choose when** you want server-rendered UI and predictable request/response flow.
- **Best fit for VB developers** because it feels similar to form/page event handling.
- **Good for**: Internal portals, CRUD/admin screens, workflow apps.

### MVC (Model-View-Controller)
- **Controller/action routing** with explicit models and views.
- **Choose when** your web app is growing in complexity and needs stronger separation of responsibilities.
- **Good for**:
  - Larger teams that want convention-driven structure.
  - Apps with reusable view composition and richer routing patterns.
  - Organizations already standardized on MVC.
- **Compared to Razor Pages**:
  - More explicit architecture and flexibility.
  - More files/moving parts, so slightly higher complexity.

### Blazor
- **Component-based web UI in C#** (instead of writing most UI logic in JavaScript).
- **Choose when** you want interactive UI behavior and strongly-typed component reuse.
- **Good for**:
  - Teams that want C# end-to-end.
  - Interactive dashboards/forms with reusable UI components.
  - Shared validation/business logic across UI and backend in .NET.
- **Hosting models**:
  - **Blazor Server**: UI updates over SignalR connection.
  - **Blazor WebAssembly**: .NET runtime in browser.
- **Tradeoffs**: Learn component lifecycle/state patterns and hosting model constraints.

## Web API

- Build REST/JSON services consumed by web/mobile/desktop clients.
- Typical patterns include minimal APIs, controllers, OpenAPI/Swagger, dependency injection, and auth.
- A strong modernization pattern is: desktop UI (WinForms/WPF) + Web API backend.

## Cloud / Background

### Worker Services
- Long-running background processes for polling, queue handling, and scheduled jobs.
- Can run as Windows Service, Linux service, container, or cloud-hosted process.

### Serverless (Azure Functions, AWS Lambda)
- Event-driven functions triggered by HTTP, queue, timer, blob events, and more.
- Choose when you need burst scaling or lightweight integration endpoints.

## Desktop + Cloud Hybrid (common VB modernization path)

- Keep/modernize desktop UX (WinForms/WPF).
- Move business rules, auth, and data APIs to ASP.NET Core services.
- Add gateway + observability patterns as system complexity grows.
