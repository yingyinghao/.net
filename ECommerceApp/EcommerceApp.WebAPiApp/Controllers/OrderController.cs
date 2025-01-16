[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllOrders()
    {
        var orders = await _orderService.GetOrdersAsync();
        return Ok(orders);
    }

    [HttpPost]
    public async Task<IActionResult> SaveOrder([FromBody] Order order)
    {
        await _orderService.AddOrderAsync(order);
        return CreatedAtAction(nameof(GetAllOrders), new { id = order.OrderId }, order);
    }

    [HttpGet("customer/{customerId}")]
    public async Task<IActionResult> GetOrderByCustomerId(int customerId)
    {
        var order = await _orderService.GetOrderByCustomerIdAsync(customerId);
        return order != null ? Ok(order) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOrder(int id)
    {
        await _orderService.DeleteOrderAsync(id);
        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateOrder(int id, [FromBody] Order order)
    {
        if (id != order.OrderId)
            return BadRequest();

        await _orderService.UpdateOrderAsync(order);
        return NoContent();
    }
}