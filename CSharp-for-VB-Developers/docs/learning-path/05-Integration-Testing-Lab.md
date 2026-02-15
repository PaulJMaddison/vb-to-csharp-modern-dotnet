# 05 - Integration Testing Lab

Primary project: `src/12-IntegrationTests`.

Goal: automate endpoint checks through the real ASP.NET Core pipeline (not manual clicking).

VB.NET mapping: this replaces repetitive manual test runs and regression spreadsheets.

## What is `WebApplicationFactory`?

`WebApplicationFactory<TProgram>` starts your API in-memory with a test server.

- No IIS setup.
- No browser automation required.
- Fast feedback with real routing/model binding/middleware.

## Prerequisites

- Modules 01-04 complete.
- Baseline tests pass:

```bash
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

---

## Exercise 5.1 - Add integration test for `/api/version`

**Goal**
- Verify metadata endpoint returns `200` and expected JSON keys.

**Steps**
1. Ensure you completed module 03 exercise adding `/api/version` in `src/11-WebApi-CleanArchitecture/Program.cs`.
2. Open `src/12-IntegrationTests/WebApiCleanTests.cs`.
3. Add test:

```csharp
[Fact]
public async Task Version_ReturnsOkWithVersionAndTime()
{
    var client = factory.CreateClient();

    var response = await client.GetAsync("/api/version");

    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    var body = await response.Content.ReadAsStringAsync();
    Assert.Contains("version", body, StringComparison.OrdinalIgnoreCase);
    Assert.Contains("serverTimeUtc", body, StringComparison.OrdinalIgnoreCase);
}
```

4. Run tests.

**Expected outcome**
- New test passes.

**Verification**

```bash
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

**Common pitfalls**
- Forgetting endpoint exists before adding test.
- Asserting full JSON string equality (too brittle).

**Stretch goal**
- Deserialize JSON and assert shape strongly.

---

## Exercise 5.2 - Add validation failure test for 400 response shape

**Goal**
- Verify invalid payload returns ProblemDetails/validation payload.

**Steps**
1. In `WebApiCleanTests.cs`, add stronger assertions around existing invalid-customer test.
2. Assert status code 400 and key fields like `title` and `errors.email`.

Example snippet:

```csharp
Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
var body = await response.Content.ReadAsStringAsync();
Assert.Contains("Validation failed", body);
Assert.Contains("email", body, StringComparison.OrdinalIgnoreCase);
```

**Expected outcome**
- Test confirms both status and payload intent.

**Verification**

```bash
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

**Common pitfalls**
- Only checking status code and missing response contract validation.

**Stretch goal**
- Parse `ValidationProblemDetails` and assert exact error count.

---

## Exercise 5.3 - Add test verifying auth required (401)

**Goal**
- Verify protected endpoint denies unauthenticated requests.

**Steps**
1. In `src/12-IntegrationTests/IntegrationTests.csproj`, add project reference:

```xml
<ProjectReference Include="..\08-WebApi-WithAuth\WebApiWithAuth.csproj" />
```

2. Create `src/12-IntegrationTests/WebApiWithAuthTests.cs`:

```csharp
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTests;

public class WebApiWithAuthTests(WebApplicationFactory<DevTokenRequest> factory)
    : IClassFixture<WebApplicationFactory<DevTokenRequest>>
{
    [Fact]
    public async Task SecureProfile_WithoutToken_Returns401()
    {
        var client = factory.CreateClient();

        var response = await client.GetAsync("/secure/profile");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }
}
```

3. Run all tests.

**Expected outcome**
- Protected endpoint test returns/pass with 401.

**Verification**

```bash
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

**Common pitfalls**
- Missing project reference to auth API project.
- Using a type from the wrong assembly in `WebApplicationFactory<TEntryPoint>`.

**Stretch goal**
- Add test that obtains dev token and verifies 200 for protected endpoint.

---

## Lab checklist

- [ ] `/api/version` integration test added
- [ ] Validation failure response test strengthened
- [ ] 401 unauthorized test added for protected route
