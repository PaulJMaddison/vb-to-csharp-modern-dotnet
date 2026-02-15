# Contributing

Thanks for helping improve this repository. This guide keeps contributions focused, teachable, and easy to review.

## Add a new sample project (without bloating diffs)

When adding a sample under `src/`:

- Keep the sample minimal and runnable.
- Prefer one concept per sample (for example: auth, background worker, or EF Core basics).
- Add short comments where a VB developer might need context, but avoid over-commenting obvious lines.
- Avoid committing large, generated, or minified assets unless they are strictly required for the lesson.
  - If an asset is required, document why in the sample README.
- Reuse existing shared patterns (logging, configuration, `Program.cs` conventions) where possible.

## Add a new lab

Labs in `docs/learning-path/` should follow a consistent structure so teams can run them in order.

Use this lab template:

1. **Goal** - what the learner should achieve.
2. **Steps** - implementation tasks in a clear sequence.
3. **Verify** - how to prove the result works (HTTP calls, UI behavior, tests).
4. **Pitfalls** - common mistakes and how to recover.
5. **Stretch** - optional advanced challenge.

Also update:

- `docs/learning-path/EXERCISES-INDEX.md`
- `docs/learning-path/README.md` (if ordering or sequencing changes)

## Run checks locally

From `CSharp-for-VB-Developers/`:

```bash
dotnet build CSharpForVBDevelopers.sln
dotnet test src/12-IntegrationTests/IntegrationTests.csproj
./scripts/run-all.sh
```

Windows PowerShell equivalent:

```powershell
./scripts/run-all.ps1
```

## Branch and PR suggestions for teams

- Use short-lived branches (for example `docs/lab-logging` or `feat/webapi-problemdetails`).
- Keep PRs focused to one teaching objective when possible.
- Prefer smaller, reviewable commits over one large commit.
- In the PR description, include:
  - learning goal,
  - impacted samples/labs,
  - verification steps run locally,
  - any follow-up work intentionally left out.
- Link related docs updates whenever code behavior changes.

## Standards and definition of done

Before opening a PR, review:

- [`docs/standards/definition-of-done.md`](docs/standards/definition-of-done.md)
- [`docs/standards/style-and-structure.md`](docs/standards/style-and-structure.md)
