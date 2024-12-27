// ECommerce.Api.Products/Data/ProductsDbContext.cs
using Microsoft.EntityFrameworkCore;

public class ProductsDbContext : DbContext
{
    public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) { }

    public DbSet<Product> Products { get; set; }
}