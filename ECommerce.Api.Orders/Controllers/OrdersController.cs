// ECommerce.Api.Orders/Controllers/OrdersController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IOrdersService _service;

    public OrdersController(IOrdersService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetByCustomerId(Guid customerId)
    {
        var result = await _service.GetByCustomerIdAsync(customerId);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Order order)
    {
        var result = await _service.CreateAsync(order);
        return CreatedAtAction(nameof(GetByCustomerId), new { customerId = order.CustomerId }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Order order)
    {
        var result = await _service.UpdateAsync(id, order);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);
        return NoContent();
    }
}