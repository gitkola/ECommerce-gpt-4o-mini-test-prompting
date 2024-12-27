// ECommerce.Api.Search/Controllers/SearchController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class SearchController : ControllerBase
{
    private readonly ISearchService _service;

    public SearchController(ISearchService service)
    {
        _service = service;
    }

    [HttpGet("{customerId}")]
    public async Task<IActionResult> GetByCustomerId(Guid customerId)
    {
        var result = await _service.GetByCustomerIdAsync(customerId);
        return Ok(result);
    }
}