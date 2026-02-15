# Definition of Done

Use these checklists before merging work.

## Web API change

- [ ] API exposes `/health` (or updates existing health endpoint behavior intentionally).
- [ ] Logging is structured (named properties, meaningful event messages).
- [ ] Errors use `ProblemDetails` responses where this repo standard applies.
- [ ] Integration tests are added or updated in `src/12-IntegrationTests`.
- [ ] Docs are updated:
  - [ ] endpoint/port notes (if changed),
  - [ ] relevant learning-path guidance.

## UI change

- [ ] UI purpose is documented (what user problem it solves and where it fits in the learning path).
- [ ] UI docs include links to the API endpoint(s) it calls, if any.

## Modernisation change

- [ ] Related modernisation guidance is updated in `docs/modernisation/`.
- [ ] New recommendations are consistent with existing roadmap and migration strategy docs.
