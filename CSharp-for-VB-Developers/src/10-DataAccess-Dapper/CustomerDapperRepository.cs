using System.Data;
using Dapper;

namespace DataAccessDapper;

// VB6 perspective:
// - ADO Recordset: very flexible but verbose and mostly string-based.
// - Dapper: still SQL-first, but maps rows to typed objects with little plumbing.
// - EF Core: higher-level model/tracking/migrations, often less SQL writing.
public class CustomerDapperRepository
{
    public async Task<IReadOnlyList<CustomerRecord>> GetCustomersAsync(IDbConnection connection)
    {
        const string sql = """
            SELECT Id, Name, Email
            FROM Customers
            ORDER BY Name;
            """;

        var rows = await connection.QueryAsync<CustomerRecord>(sql);
        return rows.ToList();
    }
}
