# 04 - Auth Lab (JWT Basics)

Primary project: `src/08-WebApi-WithAuth`.

Goal: understand token-based API auth, call protected routes, and add policy checks.

## Concepts first (VB6-friendly)

- **Cookie auth**: browser stores cookie and sends automatically (common for server-rendered web apps).
- **Token auth (JWT bearer)**: client explicitly sends `Authorization: Bearer <token>` header on every API call.
- APIs usually use tokens because mobile apps, SPAs, and services are not always browser-cookie based.

Security reminders:

- Never log full tokens.
- Never commit production signing keys.
- Dev token endpoint in this sample is for learning only.

## Prerequisites

- Modules 01-03 complete.
- Run auth API:

```bash
dotnet run --project src/08-WebApi-WithAuth/WebApiWithAuth.csproj
```

Swagger: `http://localhost:5222/swagger`

---

## Exercise 4.1 - Call a public endpoint

**Goal**
- Confirm unauthenticated API usage.

**Steps**

```bash
curl "http://localhost:5222/public/ping"
```

Or use Swagger `GET /public/ping`.

**Expected outcome**
- 200 OK with public message.

**Verification**
- Response contains `Public endpoint. No token required.`

**Common pitfalls**
- Calling wrong port.
- Assuming all endpoints need token.

**Stretch goal**
- Call through gateway path once gateway is running.

---

## Exercise 4.2 - Obtain dev token and call protected endpoint

**Goal**
- Generate token and use it in `Authorization` header.

**Steps**
1. Request token:

```bash
curl -s -X POST "http://localhost:5222/auth/dev-token" -H "Content-Type: application/json" -d '{"userName":"vb6-learner"}'
```

2. Copy `access_token` from response.
3. Call protected endpoint:

```bash
curl "http://localhost:5222/secure/profile" -H "Authorization: Bearer <paste_token_here>"
```

4. Also test without token.

**Expected outcome**
- With token: 200 OK.
- Without token: 401 Unauthorized.

**Verification**
- `User` in response is `vb6-learner`.

**Common pitfalls**
- Missing `Bearer ` prefix.
- Using expired token.

**Stretch goal**
- Use Swagger **Authorize** button with bearer token.

---

## Exercise 4.3 - Add new protected endpoint and update Swagger usage notes

**Goal**
- Add a second secure route and improve local auth instructions.

**Steps**
1. Edit `src/08-WebApi-WithAuth/Program.cs`.
2. Add endpoint:

```csharp
app.MapGet("/secure/admin-check", (ClaimsPrincipal user) =>
    Results.Ok(new
    {
        Message = "Protected admin-check endpoint",
        Name = user.Identity?.Name,
        IsInLearnerRole = user.IsInRole("Learner")
    }))
    .RequireAuthorization();
```

3. In existing `AddSecurityDefinition` description, clarify:
   - obtain token from `/auth/dev-token`
   - paste only token value in Swagger bearer auth dialog.

4. Build/run.

**Expected outcome**
- Endpoint appears in Swagger and requires auth.

**Verification**

```bash
curl -i "http://localhost:5222/secure/admin-check"
curl -i "http://localhost:5222/secure/admin-check" -H "Authorization: Bearer <token>"
```

**Common pitfalls**
- Forgetting `.RequireAuthorization()`.
- Confusing endpoint path with gateway path.

**Stretch goal**
- Add OpenAPI summary/description metadata for secure endpoints.

---

## Exercise 4.4 - Add policy/role claim check

**Goal**
- Require a specific role claim via policy.

**Steps**
1. In `Program.cs`, replace `builder.Services.AddAuthorization();` with:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("LearnerOnly", policy => policy.RequireRole("Learner"));
});
```

2. Apply policy to endpoint:

```csharp
app.MapGet("/secure/learner-zone", (ClaimsPrincipal user) =>
    Results.Ok(new { Message = "Learner policy passed", User = user.Identity?.Name }))
    .RequireAuthorization("LearnerOnly");
```

3. Run and test with dev token.

**Expected outcome**
- Dev token succeeds (has `Learner` role claim).
- Requests without token fail with 401.

**Verification**

```bash
curl -i "http://localhost:5222/secure/learner-zone"
curl -i "http://localhost:5222/secure/learner-zone" -H "Authorization: Bearer <token>"
```

**Common pitfalls**
- Role claim type mismatch.
- Registering policy but forgetting to apply it.

**Stretch goal**
- Add another policy requiring both role and custom claim.

---

## Lab checklist

- [ ] Public endpoint verified
- [ ] Token generated and protected endpoint called
- [ ] New protected endpoint added
- [ ] Role policy added and verified
