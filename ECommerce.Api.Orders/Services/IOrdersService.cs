// ECommerce.Api.Orders/Services/IOrdersService.cs
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IOrdersService
{
    Task<IEnumerable<Order>> GetAllAsync();
    Task<IEnumerable<Order>> GetByCustomerIdAsync(Guid customerId);
    Task<Order> CreateAsync(Order order);
    Task<Order> UpdateAsync(Guid id, Order order);
    Task<bool> DeleteAsync(Guid id);
}