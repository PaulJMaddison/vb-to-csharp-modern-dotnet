# 07 - Data Access Lab (No DB Required)

Primary projects:

- `src/09-DataAccess-EFCore`
- `src/10-DataAccess-Dapper`
- optional runner: `src/11-WebApi-CleanArchitecture`

Goal: compare data access approaches while keeping exercises runnable without external services.

## Prerequisites

- Modules 01-06 complete.
- Build solution once:

```bash
dotnet build CSharpForVBDevelopers.sln
```

---

## Exercise 7.1 - EF Core repository implementation (in-memory)

**Goal**
- Extend EF repository with one additional query method.

**Steps**
1. Open `src/09-DataAccess-EFCore/CustomerRepository.cs`.
2. Add to `ICustomerRepository`:

```csharp
Task<List<Customer>> FindByEmailDomainAsync(string domain, CancellationToken cancellationToken = default);
```

3. Implement method in `CustomerRepository` using LINQ.
4. Use existing in-memory registration in `src/11-WebApi-CleanArchitecture/Program.cs` to avoid real DB.
5. (Optional) add an endpoint in clean API that calls this method.

**Expected outcome**
- Build succeeds with new repository method.

**Verification**

```bash
dotnet build src/09-DataAccess-EFCore/DataAccessEfCore.csproj
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
```

**Common pitfalls (VB.NET gotchas)**
- Forgetting async suffix and cancellation token conventions.
- Writing DB-style loops instead of declarative LINQ.

**Stretch goal**
- Add paging parameters to repository method.

---

## Exercise 7.2 - Dapper repository fake/in-memory stub

**Goal**
- Provide a DB-free implementation style for learning/tests.

**Steps**
1. Open `src/10-DataAccess-Dapper/CustomerDapperRepository.cs`.
2. Add an overload method that accepts `IReadOnlyList<CustomerRecord>` and filters in-memory (demo-only).

```csharp
public Task<IReadOnlyList<CustomerRecord>> GetCustomersFromStubAsync(IReadOnlyList<CustomerRecord> seed)
{
    var result = seed.OrderBy(x => x.Name).ToList();
    return Task.FromResult<IReadOnlyList<CustomerRecord>>(result);
}
```

3. Build dapper project.

**Expected outcome**
- Dapper project compiles with a no-DB training stub method.

**Verification**

```bash
dotnet build src/10-DataAccess-Dapper/DataAccessDapper.csproj
```

**Common pitfalls (VB.NET gotchas)**
- Mixing production data access and teaching stubs without clear naming.
- Assuming Dapper manages connections automatically like EF context lifetime.

**Stretch goal**
- Add a small unit test project around Dapper stub behavior.

---

## Exercise 7.3 - Compare EF vs Dapper vs ADO (decision note)

**Goal**
- Build architectural judgment, not just syntax familiarity.

**Steps**
1. Read `docs/patterns/data-access-ef-vs-dapper.md`.
2. Create a short table in your notes/PR:
   - team skill fit
   - query complexity
   - migration support
   - performance tuning visibility
3. Pick one approach for:
   - CRUD-heavy internal module
   - reporting-heavy read module

**Expected outcome**
- You can explain tradeoffs clearly for real modernization decisions.

**Verification**
- Peer/trainer review of your decision note.

**Common pitfalls (VB.NET gotchas)**
- Searching for one “always best” data tool.
- Ignoring maintainability and onboarding cost.

**Stretch goal**
- Propose a hybrid strategy (EF for writes, Dapper for heavy reads).

---

## Optional: with Docker database

> Optional only. Do not block training if Docker is unavailable.

1. Start SQL Server container:

```bash
docker compose up -d
```

2. Confirm container running:

```bash
docker ps
```

3. If migrations exist in your branch/project, apply them.
4. Run smoke-test endpoint from clean API and verify non-error response.

If migrations are not present, keep using in-memory provider for labs.

---

## Lab checklist

- [ ] EF repository extension completed
- [ ] Dapper stub extension completed
- [ ] Tradeoff comparison documented
- [ ] Optional Docker DB path attempted (if available)
