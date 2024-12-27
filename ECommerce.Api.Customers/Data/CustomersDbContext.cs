// ECommerce.Api.Customers/Data/CustomersDbContext.cs
using Microsoft.EntityFrameworkCore;

public class CustomersDbContext : DbContext
{
    public CustomersDbContext(DbContextOptions<CustomersDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
}