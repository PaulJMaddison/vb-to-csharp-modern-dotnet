namespace DataAccessEfCore;

public class CustomerService(ICustomerRepository repository, AppDbContext dbContext)
{
    public Task<List<Customer>> GetCustomersAsync(CancellationToken cancellationToken = default) =>
        repository.GetAllAsync(cancellationToken);

    public async Task<Customer> CreateCustomerAsync(string name, string email, CancellationToken cancellationToken = default)
    {
        var customer = new Customer
        {
            Name = name,
            Email = email
        };

        await repository.AddAsync(customer, cancellationToken);

        // VB.NET comparison: instead of connection.BeginTrans + multiple SQL statements,
        // SaveChanges groups tracked operations into one transactional unit-of-work.
        await dbContext.SaveChangesAsync(cancellationToken);
        return customer;
    }
}
