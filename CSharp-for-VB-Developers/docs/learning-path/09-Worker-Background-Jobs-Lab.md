# 09 - Worker & Background Jobs Lab

Primary project: `src/05-WorkerService`.

Goal: implement safe background processing patterns.

Key rule: do not run long work inside web request threads when it should be asynchronous/background.

## Prerequisites

- Modules 01-08 complete.
- Optional: run clean API if calling it from worker.

---

## Exercise 9.1 - Add timed job that logs and calls API

**Goal**
- Perform periodic work with cancellation support.

**Steps**
1. Edit `src/05-WorkerService/Worker.cs`.
2. Inject `IHttpClientFactory` into worker constructor.
3. Inside loop:
   - log start time
   - call `http://localhost:5111/health`
   - log status code
4. In `src/05-WorkerService/Program.cs`, register HTTP client:

```csharp
builder.Services.AddHttpClient();
```

5. Run worker:

```bash
dotnet run --project src/05-WorkerService/WorkerService.csproj
```

**Expected outcome**
- Every interval, worker logs call attempt and result.

**Verification**
- Console logs show repeated timestamps and API response status.

**Common pitfalls (VB.NET gotchas)**
- Using blocking calls (`.Result`) in async loop.
- Ignoring cancellation token in delays or HTTP calls.

**Stretch goal**
- Add retry with exponential backoff for transient failures.

---

## Exercise 9.2 - Add configuration setting in `appsettings.json`

**Goal**
- Control interval without recompiling.

**Steps**
1. Edit `src/05-WorkerService/appsettings.json` and add:

```json
"WorkerOptions": {
  "IntervalSeconds": 10,
  "HealthUrl": "http://localhost:5111/health"
}
```

2. Bind config in `Program.cs` (options pattern).
3. Use configured values in worker loop.
4. Run and verify interval change.

**Expected outcome**
- Worker interval/URL come from configuration.

**Verification**
- Change interval in config and observe behavior after restart.

**Common pitfalls**
- Hardcoding URLs inside worker logic.
- Forgetting to restart app after config edit.

**Stretch goal**
- Add environment-specific override in `appsettings.Development.json`.

---

## Exercise 9.3 - Windows Service hosting (doc-only, optional)

**Goal**
- Understand production-style hosting path.

**Steps (optional)**
1. Add Windows service support:

```csharp
builder.Services.AddWindowsService(options => options.ServiceName = "VbToCSharpWorker");
```

2. Publish worker executable.
3. Register service on Windows (admin PowerShell) with `sc.exe` or `New-Service`.

**Expected outcome**
- You understand deployment model even if not executed in training.

**Verification**
- Document commands and deployment notes in your PR/readme.

**Common pitfalls**
- Running service with insufficient permissions.
- Not configuring log sink suitable for service environment.

**Stretch goal**
- Add Linux `systemd` notes for cross-platform teams.

---

## Lab checklist

- [ ] Timed worker job implemented
- [ ] Config-driven interval implemented
- [ ] Windows Service hosting approach documented
