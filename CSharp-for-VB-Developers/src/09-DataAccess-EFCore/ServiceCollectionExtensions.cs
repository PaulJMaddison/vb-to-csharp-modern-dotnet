using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccessEfCore;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccessEfCore(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<CustomerService>();
        return services;
    }
}
