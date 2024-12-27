// ECommerce.Api.Customers/Services/ICustomersService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ICustomersService
{
    Task<IEnumerable<Customer>> GetAllAsync();
    Task<Customer> GetByIdAsync(Guid id);
    Task<Customer> CreateAsync(Customer customer);
    Task<Customer> UpdateAsync(Guid id, Customer customer);
    Task<bool> DeleteAsync(Guid id);
}