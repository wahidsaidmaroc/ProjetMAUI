using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.OrderService;

namespace OrderManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderServices;

    public OrderController(IOrderService orderService)
    {
        _orderServices = orderService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderDto>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<OrderDto>> Get()
    {
        return Ok(_orderServices.GetOrders());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderDto> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Valid id is required.");
        }

        var order = _orderServices.GetOrder(id);

        if (order == null)
        {
            return NotFound();
        }

        return Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderDto> Post([FromBody] OrderDto value)
    {
        if (value == null)
        {
            return BadRequest("Payload is required.");
        }

        if (value.OrderDate == default)
        {
            return BadRequest("Order date is required.");
        }

        var created = _orderServices.AddOrder(value);
        return Created($"api/Order/{created.Cle}", created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(int id, [FromBody] OrderDto value)
    {
        if (value == null || id <= 0)
        {
            return BadRequest("Valid id and payload are required.");
        }

        if (value.Cle != 0 && value.Cle != id)
        {
            return BadRequest("Payload id must match route id.");
        }

        var updated = _orderServices.UpdateOrder(id, value);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Valid id is required.");
        }

        var deleted = _orderServices.DeleteOrder(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}