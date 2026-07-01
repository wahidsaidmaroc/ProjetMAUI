using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public interface IOrderItemsRepository
{
    OrderItems AddOrderItem(OrderItems orderItem);
    bool Delete(int id);
    OrderItems? Get(int id);
    IList<OrderItems> GetOrderItems();
    bool Update(OrderItems orderItem);
}