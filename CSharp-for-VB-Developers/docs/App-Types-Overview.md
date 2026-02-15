# C#/.NET Application Types (VB Windows Developer View)

## Windows Desktop
### WinForms
- Easiest transition from VB WinForms
- Event-driven UI, drag/drop designer
- Great for internal tools, admin apps, quick UI

### WPF
- More powerful UI composition + data binding + MVVM patterns
- Better for rich UI, modern styling
- Learning curve: XAML + MVVM

## Web
### Web Apps
- **ASP.NET Core Razor Pages**: server-rendered UI, very approachable
- **MVC**: more structure, more moving parts (still common)
- **Blazor**: C# in the browser UI model (server or WASM)

## Web API
- Build REST/JSON services used by apps
- Modern patterns: minimal APIs, controllers, OpenAPI/Swagger, DI, auth

## Cloud / Background
### Worker Services
- Long-running background processes
- Often hosted as Windows Services, Linux daemons, containers, or cloud apps

### Serverless (Azure Functions, AWS Lambda)
- Event-driven functions triggered by HTTP, queues, timers, etc.
- Great for integrations and burst workloads

## Desktop + Cloud Hybrid
- Desktop app calls Web API in cloud
- Central auth, data, business rules on the server

