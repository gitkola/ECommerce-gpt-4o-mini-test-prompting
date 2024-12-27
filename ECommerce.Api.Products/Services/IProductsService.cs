// ECommerce.Api.Products/Services/IProductsService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductsService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(Guid id);
    Task<Product> CreateAsync(Product product);
    Task<Product> UpdateAsync(Guid id, Product product);
    Task<bool> DeleteAsync(Guid id);
}