namespace OrderManagement.Application.OrderService;

public interface IOrderService
{
    OrderDto AddOrder(OrderDto orderDto);
    bool DeleteOrder(int id);
    OrderDto? GetOrder(int id);
    List<OrderDto> GetOrders();
    bool UpdateOrder(int id, OrderDto orderDto);
}