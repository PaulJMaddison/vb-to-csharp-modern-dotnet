# 04 - Auth Lab

## Goal

Learn token-based authentication in ASP.NET Core and practice calling protected endpoints through standard developer tooling.

## Steps

1. Run auth API:
   ```bash
   dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
   ```
2. Open Swagger at `http://localhost:5222/swagger`.
3. Execute the token/login endpoint provided by the sample.
4. Use **Authorize** in Swagger with the returned bearer token.
5. Call protected endpoint(s) and compare with anonymous access behavior.

## Verify

- You can obtain a token from the sample login/token endpoint.
- Protected endpoint returns success with token and unauthorized without token.
- You can explain authentication vs authorization in one sentence each.

## Common VB6 pitfalls

- Treating auth as a UI concern rather than API middleware/pipeline concern.
- Passing credentials repeatedly instead of short-lived token flow.
- Hardcoding secrets in source files.

## Stretch goals

- Add role/claim-based policy and verify access differences.
- Move auth settings into environment-based configuration.
