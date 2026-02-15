# 10 - Capstone Project (1-2 Days)

Scenario: modernize one legacy module behind a gateway using incremental delivery.

Goal: apply APIs, auth, testing, gateway routing, UI, and observability together.

## Capstone requirements

Implement all of the following:

1. **New API endpoints** in `src/11-WebApi-CleanArchitecture` (or agreed API project).
2. **Auth-protected route** in `src/08-WebApi-WithAuth`.
3. **Integration tests** in `src/12-IntegrationTests`.
4. **Gateway route** update in `src/13-ReverseProxy-Gateway/appsettings.json`.
5. **Simple UI page** in one project:
   - `src/03-WebApp-RazorPages`
   - or `src/07-MvcWebApp`
   - or `src/06-BlazorWebApp`
6. **Logging + correlation id** visible in logs/headers.

## Suggested feature narrative

- Legacy module: "Customer Notes"
- Deliver:
  - `GET /api/version`
  - `POST /api/notes`
  - `GET /secure/learner-zone`
  - gateway route `/moduleA/*`
  - UI form to submit/read notes

## Definition of done (checklist)

- [ ] Solution builds: `dotnet build CSharpForVBDevelopers.sln`
- [ ] Tests pass: `dotnet test src/12-IntegrationTests/IntegrationTests.csproj`
- [ ] New endpoints visible in Swagger
- [ ] Protected endpoint returns 401 without token and 200 with token
- [ ] Gateway route forwards successfully
- [ ] UI page is functional and demonstrable
- [ ] Logs include structured entries and correlation id
- [ ] README or PR notes explain run/verify steps

## Verification script (manual)

1. Start services (`scripts/run-all.*`).
2. Verify API health/version endpoints.
3. Obtain token from `/auth/dev-token` and call protected route.
4. Run integration tests.
5. Run selected UI project and validate user flow.
6. Demonstrate request through gateway with correlation header.

## Suggested PR breakdown (small incremental PRs)

1. **PR 1**: API endpoint scaffolding (`/api/version`, DTOs).
2. **PR 2**: validation + structured logging.
3. **PR 3**: auth-protected endpoint + policy.
4. **PR 4**: integration tests (200/400/401 scenarios).
5. **PR 5**: gateway route + correlation forwarding.
6. **PR 6**: UI page wiring and final docs.

VB.NET mapping: many small merges reduce risk versus one “big bang” rewrite.

## Trainer facilitation notes

- Ask each participant to demo one vertical slice end-to-end.
- Encourage peer review focused on readability and operability (logs/tests), not only features.
- Timebox stretch goals after required checklist is complete.
