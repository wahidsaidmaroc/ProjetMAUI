using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public interface IOrderRepository
{
    Order AddOrder(Order order);
    bool Delete(int id);
    Order? Get(int id);
    IList<Order> GetOrders();
    bool Update(Order order);
}