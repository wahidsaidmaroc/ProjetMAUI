using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.OrderItemsService;

namespace OrderManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IOrderItemsService _orderItemsServices;

    public OrderItemsController(IOrderItemsService orderItemsService)
    {
        _orderItemsServices = orderItemsService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<OrderItemDto>), StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<OrderItemDto>> Get()
    {
        return Ok(_orderItemsServices.GetOrderItems());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<OrderItemDto> Get(int id)
    {
        if (id <= 0)
        {
            return BadRequest("Valid id is required.");
        }

        var orderItem = _orderItemsServices.GetOrderItem(id);

        if (orderItem == null)
        {
            return NotFound();
        }

        return Ok(orderItem);
    }

    [HttpPost]
    [ProducesResponseType(typeof(OrderItemDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<OrderItemDto> Post([FromBody] OrderItemDto value)
    {
        if (value == null)
        {
            return BadRequest("Payload is required.");
        }

        if (value.ProductId <= 0 || value.OrderId <= 0 || value.Qnt <= 0)
        {
            return BadRequest("ProductId, OrderId and Qnt must be valid.");
        }

        var created = _orderItemsServices.AddOrderItem(value);
        return Created($"api/OrderItems/{created.Cle}", created);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Put(int id, [FromBody] OrderItemDto value)
    {
        if (value == null || id <= 0)
        {
            return BadRequest("Valid id and payload are required.");
        }

        if (value.Cle != 0 && value.Cle != id)
        {
            return BadRequest("Payload id must match route id.");
        }

        var updated = _orderItemsServices.UpdateOrderItem(id, value);

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

        var deleted = _orderItemsServices.DeleteOrderItem(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}