# Logging and Correlation

Use structured logging (`logger.LogInformation("Order {OrderId}", id)`) instead of string concatenation.
A correlation id ties logs across gateway/API/services so one request can be traced end-to-end.

`11-WebApi-CleanArchitecture` includes middleware adding/propagating `X-Correlation-Id`.
