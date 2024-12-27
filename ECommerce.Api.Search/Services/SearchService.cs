// ECommerce.Api.Search/Services/SearchService.cs
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class SearchService : ISearchService
{
    private readonly HttpClient _httpClient;

    public SearchService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<object> GetByCustomerIdAsync(Guid customerId)
    {
        // Отримати дані про покупця
        var customerResponse = await _httpClient.GetAsync($"http://localhost:5001/api/customers/{customerId}");
        if (!customerResponse.IsSuccessStatusCode)
        {
            return new { ErrorString = "Customer not found", isSuccessful = false };
        }

        var customer = await customerResponse.Content.ReadFromJsonAsync<Customer>();

        // Отримати замовлення для покупця
        var ordersResponse = await _httpClient.GetAsync($"http://localhost:5002/api/orders/customer/{customerId}");
        if (!ordersResponse.IsSuccessStatusCode)
        {
            return new { ErrorString = "Orders not found", isSuccessful = false };
        }

        var orders = await ordersResponse.Content.ReadFromJsonAsync<List<Order>>();

        // Отримати продукти з усіх замовлень
        var productIds = new HashSet<Guid>();
        foreach (var order in orders)
        {
            foreach (var item in order.OrderItems)
            {
                productIds.Add(item.ProductId);
            }
        }

        var products = new Dictionary<Guid, Product>();
        foreach (var productId in productIds)
        {
            var productResponse = await _httpClient.GetAsync($"http://localhost:5003/api/products/{productId}");
            if (productResponse.IsSuccessStatusCode)
            {
                var product = await productResponse.Content.ReadFromJsonAsync<Product>();
                products[productId] = product;
            }
        }

        // Формування результату
        return new
        {
            customer = new
            {
                id = customer.Id,
                name = customer.Name,
                email = customer.Email
            },
            orders = orders,
            products = products
        };
    }
}