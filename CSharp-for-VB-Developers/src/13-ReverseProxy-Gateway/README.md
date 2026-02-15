# ReverseProxyGateway

`ReverseProxyGateway` is the **front door** for strangler migrations. Clients call the gateway and it forwards traffic to modernized APIs.

## Default routing

- `/api/*` -> `WebApiClean` at `http://localhost:5111` (or `WebApiMinimal` if you switch to `http://localhost:63759`).
- `/auth/*` -> `WebApiWithAuth` at `http://localhost:5222`.

## Run locally

From the repository root:

```bash
# Terminal 1 - downstream API
cd src/11-WebApi-CleanArchitecture
dotnet run

# Terminal 2 - optional auth API
cd src/08-WebApi-WithAuth
dotnet run

# Terminal 3 - gateway
cd src/13-ReverseProxy-Gateway
dotnet run
```

Gateway default URL: `http://localhost:5000`

Example calls:

```bash
curl http://localhost:5000/api/weatherforecast
curl http://localhost:5000/auth/health
```

## Optional auth route (if WebApiWithAuth is not available)

JSON does not support comments, so keep this sample snippet here and add it to `appsettings.json` only when the auth API exists:

```json
{
  "Routes": {
    "webApiWithAuthRoute": {
      "ClusterId": "webApiWithAuthCluster",
      "Match": { "Path": "/auth/{**catch-all}" }
    }
  },
  "Clusters": {
    "webApiWithAuthCluster": {
      "Destinations": {
        "destination1": { "Address": "http://localhost:5222/" }
      }
    }
  }
}
```
