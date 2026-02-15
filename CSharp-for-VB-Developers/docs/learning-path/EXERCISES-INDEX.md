# Exercises Index (Planning View)

Use this page to plan self-study, cohort sessions, or workshop agendas.

Legend:

- **Time**: S (15-30m), M (30-90m), L (90m+)
- **Difficulty**: 1 (intro) to 5 (advanced)

| Module | Exercise | Time | Difficulty | Related Projects | Prerequisites |
|---|---|---:|---:|---|---|
| 01 | First build + run console/API | S | 1 | `src/02-ConsoleCSharp`, `src/04-WebApi-Minimal` | None |
| 02 | Nullable reference types | S | 2 | `src/04-WebApi-Minimal` | 01 |
| 02 | String interpolation | S | 1 | `src/02-ConsoleCSharp` | 01 |
| 02 | Records vs classes | M | 2 | `src/04-WebApi-Minimal` | 01 |
| 02 | LINQ basics | M | 2 | `src/11-WebApi-CleanArchitecture` | 01 |
| 03 | Add `GET /api/version` | S | 2 | `src/11-WebApi-CleanArchitecture` | 01-02 |
| 03 | Add POST DTO + validation | M | 3 | `src/11-WebApi-CleanArchitecture` | 01-02 |
| 03 | Structured logging | S | 2 | `src/11-WebApi-CleanArchitecture` | 01-02 |
| 04 | Call public endpoint | S | 1 | `src/08-WebApi-WithAuth` | 03 |
| 04 | Obtain token + call protected endpoint | M | 2 | `src/08-WebApi-WithAuth` | 03 |
| 04 | Add protected endpoint + Swagger note | M | 3 | `src/08-WebApi-WithAuth` | 03 |
| 04 | Add role policy check | M | 3 | `src/08-WebApi-WithAuth` | 03 |
| 05 | Integration test for `/api/version` | S | 2 | `src/12-IntegrationTests`, `src/11-WebApi-CleanArchitecture` | 03 |
| 05 | Validation failure shape test | S | 2 | `src/12-IntegrationTests` | 03 |
| 05 | Auth-required test (401) | M | 3 | `src/12-IntegrationTests`, `src/08-WebApi-WithAuth` | 04 |
| 06 | Add `/legacy/*` route | S | 2 | `src/13-ReverseProxy-Gateway` | 03-04 |
| 06 | Add `/moduleA/*` route | S | 2 | `src/13-ReverseProxy-Gateway` | 03-04 |
| 06 | Correlation ID forwarding | M | 3 | `src/13-ReverseProxy-Gateway`, `src/11-WebApi-CleanArchitecture` | 03-04 |
| 07 | EF repository extension (in-memory) | M | 3 | `src/09-DataAccess-EFCore` | 03 |
| 07 | Dapper stub extension | M | 3 | `src/10-DataAccess-Dapper` | 03 |
| 07 | EF vs Dapper vs ADO decision note | S | 2 | `docs/patterns/data-access-ef-vs-dapper.md` | 03 |
| 08 | Razor Pages form/handler enhancement | M | 2 | `src/03-WebApp-RazorPages` | 03 |
| 08 | MVC controller/action/view enhancement | M | 2 | `src/07-MvcWebApp` | 03 |
| 08 | Blazor component/binding enhancement | M | 2 | `src/06-BlazorWebApp` | 03 |
| 09 | Worker timed job + API call | M | 3 | `src/05-WorkerService` | 03 |
| 09 | Config-driven worker interval | S | 2 | `src/05-WorkerService` | 03 |
| 09 | Windows Service hosting (doc-only) | S | 2 | `src/05-WorkerService` | 03 |
| 10 | Capstone modernization slice | L | 4 | API/Auth/Test/Gateway/UI projects | 01-09 |

## Suggested session packs

- **Kickoff pack (half day)**: 01 + selected 02 + 03.1
- **API confidence pack (half day)**: 03 + 04
- **Quality pack (half day)**: 05 + 06.3
- **Architecture pack (half day)**: 06 + 07
- **UI/Worker pack (half day)**: 08 + 09
- **Capstone day(s)**: 10
