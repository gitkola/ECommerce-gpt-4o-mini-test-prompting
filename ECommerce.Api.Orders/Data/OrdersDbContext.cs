// ECommerce.Api.Orders/Data/OrdersDbContext.cs
using Microsoft.EntityFrameworkCore;

public class OrdersDbContext : DbContext
{
    public OrdersDbContext(DbContextOptions<OrdersDbContext> options) : base(options) { }

    public DbSet<Order> Orders { get; set; }
}