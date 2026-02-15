# Error Handling and ProblemDetails

ProblemDetails is the standard JSON error format in modern ASP.NET Core APIs.
Use:
- validation responses (`Results.ValidationProblem`)
- centralized exception handling (`UseExceptionHandler` + `AddProblemDetails`)

This keeps client-side error handling predictable.
