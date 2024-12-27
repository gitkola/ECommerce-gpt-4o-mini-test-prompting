// ECommerce.Api.Search/Services/ISearchService.cs
using System.Threading.Tasks;

public interface ISearchService
{
    Task<object> GetByCustomerIdAsync(Guid customerId);
}