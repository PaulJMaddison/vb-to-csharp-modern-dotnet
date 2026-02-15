# Dependency Injection

Dependency injection (DI) replaces hand-built global singletons/common modules with explicit registrations.
In ASP.NET Core, register services in `Program.cs`, then request them in constructors or endpoint parameters.

For VB.NET developers: think of DI as a safer, testable way to manage shared dependencies.
