# 04 - ASP.NET Framework (System.Web) to ASP.NET Core

Moving from ASP.NET Framework to ASP.NET Core is not just a target-framework change; it is a **web stack migration**.

## Key difference to understand first

## ASP.NET Framework (System.Web)
- Built around the classic ASP.NET pipeline and `System.Web`.
- Uses patterns like `HttpContext.Current`, HttpModules/HttpHandlers, Global.asax lifecycle hooks, and legacy configuration conventions.

## ASP.NET Core
- Uses a modern middleware pipeline, dependency injection by default, and generic host configuration.
- Uses endpoint routing and explicit app startup composition.
- Different hosting and deployment assumptions.

Because these models differ, direct mechanical conversion is limited.

## Why migration is non-trivial
Common complexity drivers:
- Pipeline and lifecycle differences (module/handler model vs middleware).
- Authentication/authorization redesign (cookies, token flows, policy mapping).
- Replacing legacy server controls and framework-specific middleware.
- Reworking session/cache/state assumptions.
- Revalidating behavior behind proxies/load balancers.

## Practical migration approach
Use **incremental patterns** instead of a big rewrite when possible:

1. **Define a routing boundary**
   - Keep existing ASP.NET Framework app running.
   - Route selected paths/features to new ASP.NET Core endpoints.

2. **Extract business logic from web framework dependencies**
   - Move reusable services and domain logic into shared libraries.
   - Reduce direct usage of `System.Web`-specific constructs.

3. **Migrate vertical slices**
   - Move one feature set at a time (API area, bounded page group, auth-adjacent feature).
   - Validate each slice in production-like environments.

4. **Retire legacy endpoints gradually**
   - Shift traffic progressively.
   - Keep observability on both sides during transition.

## Incremental patterns that work well
- **Strangler pattern:** new ASP.NET Core endpoints progressively replace old endpoints.
- **Facade/gateway boundary:** route and normalize requests during coexistence.
- **Shared contract libraries:** DTOs and validation contracts reused by old and new stacks.

## Routing boundary emphasis
The routing boundary is often the control point that makes migration safer:
- Enables feature-by-feature cutover.
- Limits blast radius of failures.
- Supports rollback per route or feature area.
- Lets teams compare legacy vs modern behavior in parallel.

## Migration planning checklist (web-specific)
- Inventory all `System.Web` touchpoints.
- Map auth/session behavior before touching code.
- Decide on coexistence routing strategy early.
- Establish end-to-end tests for critical user journeys.
- Define cutover and rollback criteria per migrated slice.
