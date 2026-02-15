# Style and Structure Standards

These standards keep samples and labs clear for teams moving from VB to modern .NET.

## Sample projects (`src/*`)

- Keep sample scope tight: one primary lesson per project.
- Favor readable defaults over advanced abstractions unless the abstraction is the lesson.
- Use explicit naming for files and classes (`WebApiWithAuth`, `CustomerRepository`, etc.).
- Keep startup/configuration discoverable in `Program.cs` and `appsettings.json`.

## Labs and docs (`docs/*`)

- Write for practitioners: concise, task-oriented instructions.
- Prefer step-by-step flow over long conceptual blocks.
- Include verification commands or expected outputs.
- Call out pitfalls proactively, especially migration-specific traps.
- Cross-link related docs (patterns, modernisation, learning-path entries).

## Diff hygiene

- Avoid unrelated formatting churn in files not part of the change.
- Avoid large binary/minified additions unless necessary for a runnable lesson.
- If a change introduces generated content, document why it is committed.
