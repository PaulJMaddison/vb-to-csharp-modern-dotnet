using Microsoft.EntityFrameworkCore;

namespace DataAccessEfCore;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task AddAsync(Customer customer, CancellationToken cancellationToken = default);
}

public class CustomerRepository(AppDbContext dbContext) : ICustomerRepository
{
    public Task<List<Customer>> GetAllAsync(CancellationToken cancellationToken = default) =>
        dbContext.Customers
            .AsNoTracking() // Read-only query: no change tracking overhead.
            .OrderBy(c => c.Name)
            .ToListAsync(cancellationToken);

    public Task<Customer?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        dbContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

    public Task AddAsync(Customer customer, CancellationToken cancellationToken = default) =>
        dbContext.Customers.AddAsync(customer, cancellationToken).AsTask();
}
