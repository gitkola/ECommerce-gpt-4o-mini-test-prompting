// ECommerce.Api.Search/Services/ISearchService.cs
using System;
using System.Threading.Tasks;

public interface ISearchService
{
    Task<object> GetByCustomerIdAsync(Guid customerId);
}