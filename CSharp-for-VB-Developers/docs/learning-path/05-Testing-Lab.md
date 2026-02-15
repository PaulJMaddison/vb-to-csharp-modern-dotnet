# 05 - Testing Lab

## Goal

Build confidence in automated API verification using integration tests instead of manual-only regression checks.

## Steps

1. Run integration tests:
   ```bash
   dotnet test src/12-IntegrationTests/IntegrationTests.csproj
   ```
2. Inspect one test case that hosts the app in memory.
3. Add or modify one assertion for status code or response shape.
4. Re-run tests and confirm deterministic results.

## Verify

- Test project runs successfully from CLI.
- At least one endpoint behavior is verified with assertions.
- Learner can explain why integration tests catch pipeline issues unit tests may miss.

## Common VB.NET pitfalls

- Relying on “click-through” verification as the primary test strategy.
- Writing fragile tests tied to non-deterministic ordering/time assumptions.
- Skipping test data setup/cleanup discipline.

## Stretch goals

- Add a negative-path test (validation error, unauthorized, or not found).
- Wire test execution into CI pipeline policy for pull requests.
