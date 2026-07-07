namespace OrderManagement.Application.OrderItemsService;

public interface IOrderItemsService
{
    OrderItemDto AddOrderItem(OrderItemDto orderItemDto);
    bool DeleteOrderItem(int id);
    OrderItemDto? GetOrderItem(int id);
    List<OrderItemDto> GetOrderItems();
    bool UpdateOrderItem(int id, OrderItemDto orderItemDto);
}