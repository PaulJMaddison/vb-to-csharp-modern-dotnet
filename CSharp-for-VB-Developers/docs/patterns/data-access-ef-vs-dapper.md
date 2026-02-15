# Data Access: EF Core vs Dapper

- **EF Core**: model-centric, change tracking, migrations, LINQ queries.
- **Dapper**: SQL-centric, very light abstraction over ADO.NET.

If you want fast custom SQL with minimal ceremony, Dapper is great.
If you want a richer domain model and less SQL plumbing, EF Core is often better.
