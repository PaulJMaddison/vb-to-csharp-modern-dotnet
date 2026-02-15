# 06 - Gateway + Strangler Lab

## Goal

Practice routing multiple backend APIs behind a single gateway and understand how strangler migration enables gradual modernization.

## Steps

1. Start the lab stack:
   - `src/08-WebApi-WithAuth`
   - `src/11-WebApi-CleanArchitecture`
   - `src/13-ReverseProxy-Gateway`
2. Call downstream APIs directly first (baseline).
3. Call equivalent routes through gateway (`http://localhost:5000/...`).
4. Review gateway route configuration and map each route to its destination service.
5. Discuss a real VB6 module that could be migrated behind a gateway-first facade.

## Verify

- Gateway forwards requests successfully to at least two backend endpoints.
- You can identify where route mapping is configured.
- Team can describe one concrete strangler slice candidate.

## Common VB6 pitfalls

- Attempting “big-bang rewrite” instead of incremental strangler slices.
- Coupling clients directly to many backend services without a stable edge API.
- Underestimating observability and tracing needs across hops.

## Stretch goals

- Add one new gateway route to an existing backend endpoint.
- Add request/response logging correlation across gateway and downstream APIs.
