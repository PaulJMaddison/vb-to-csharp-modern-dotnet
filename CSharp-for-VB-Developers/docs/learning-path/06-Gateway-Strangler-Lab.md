# 06 - Gateway Strangler Lab

Primary project: `src/13-ReverseProxy-Gateway`.

Goal: use gateway routing as a safe modernization boundary (strangler pattern).

## Front-door routing diagram

```text
Browser/Client
     |
     v
+--------------------+
| Gateway (YARP)     |  http://localhost:5000
| - /api/*           |--> WebApiClean (5111)
| - /auth/*          |--> WebApiWithAuth (5222)
| - /legacy/* (new)  |--> Placeholder service
| - /moduleA/* (new) |--> New module endpoint
+--------------------+
```

VB6 mapping: gateway is like a stable menu/main form entry point while internals are gradually replaced.

## Prerequisites

- Modules 01-05 complete.
- Start clean API, auth API, gateway (script or manual).

---

## Exercise 6.1 - Add route `/legacy/*` to placeholder service

**Goal**
- Simulate routing old endpoints without changing clients.

**Steps**
1. Edit `src/13-ReverseProxy-Gateway/appsettings.json`.
2. Under `ReverseProxy:Routes`, add:

```json
"legacyRoute": {
  "ClusterId": "legacyCluster",
  "Match": { "Path": "/legacy/{**catch-all}" },
  "Transforms": [
    { "PathRemovePrefix": "/legacy" }
  ]
}
```

3. Under `ReverseProxy:Clusters`, add:

```json
"legacyCluster": {
  "Destinations": {
    "destination1": { "Address": "http://localhost:5111/" }
  }
}
```

4. Restart gateway.

**Expected outcome**
- Requests to `/legacy/...` are forwarded.

**Verification**

```bash
curl "http://localhost:5000/legacy/health"
```

(With prefix removal transform, this forwards to clean API `/health`.)

**Common pitfalls**
- Missing trailing slash in destination address.
- Route path typo (`{**catch-all}`).

**Stretch goal**
- Point placeholder to a tiny mock API on another local port.

---

## Exercise 6.2 - Add route `/moduleA/*` to new API path

**Goal**
- Expose a new module path without changing upstream clients.

**Steps**
1. In same gateway config, add route:

```json
"moduleARoute": {
  "ClusterId": "webApiCleanCluster",
  "Match": { "Path": "/moduleA/{**catch-all}" },
  "Transforms": [
    { "PathPattern": "/api/{**catch-all}" }
  ]
}
```

2. Restart gateway.
3. Call module route:

```bash
curl "http://localhost:5000/moduleA/customers"
```

**Expected outcome**
- Route forwards to clean API customer endpoint.

**Verification**
- Response is same shape as `/api/customers` from clean API.

**Common pitfalls**
- Forgetting to add transform when the downstream route shape differs.
- Not understanding that match + destination do forwarding, not business logic.

**Stretch goal**
- Add transform rule to rewrite path segment explicitly.

---

## Exercise 6.3 - Correlation ID forwarding

**Goal**
- Forward/request correlation header across gateway to backend services.

**Steps**
1. In `appsettings.json`, add per-route transforms (example for `webApiCleanRoute`):

```json
"Transforms": [
  { "RequestHeader": "X-Correlation-ID", "Set": "{RequestHeader:X-Correlation-ID}" }
]
```

2. Send request with custom header:

```bash
curl -H "X-Correlation-ID: lp-12345" "http://localhost:5000/api/customers"
```

3. Check clean API logs (`src/11-WebApi-CleanArchitecture/CorrelationIdMiddleware.cs` logic).

**Expected outcome**
- Correlation id is preserved or propagated and visible in downstream logs/response headers.

**Verification**
- Observe header and trace id behavior in logs or response headers.

**Common pitfalls**
- Using inconsistent header names (`X-Correlation-Id` vs `X-Correlation-ID`).
- Expecting correlation to work without middleware support downstream.

**Stretch goal**
- Add standard `traceparent` documentation and forward both headers.

---

## Why this supports strangler modernization

- Keep client URLs stable while migrating internals one route at a time.
- Move modules behind gateway incrementally.
- Roll back by route config if needed (low-risk cutover).

## Lab checklist

- [ ] `/legacy/*` route added and verified
- [ ] `/moduleA/*` route added and verified
- [ ] Correlation header forwarding documented/tested
