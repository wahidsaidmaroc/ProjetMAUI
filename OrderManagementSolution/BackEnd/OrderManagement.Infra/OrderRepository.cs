using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public class OrderRepository : IOrderRepository
{
    private readonly AppMyDbContext _appMyDbContext;

    public OrderRepository(AppMyDbContext appMyDbContext)
    {
        _appMyDbContext = appMyDbContext;
    }

    public Order AddOrder(Order order)
    {
        _appMyDbContext.Orders.Add(order);
        _appMyDbContext.SaveChanges();

        order.OrderNbr = order.Id;
        _appMyDbContext.SaveChanges();

        return order;
    }

    public bool Delete(int id)
    {
        var existing = _appMyDbContext.Orders.Find(id);

        if (existing == null)
        {
            return false;
        }

        _appMyDbContext.Orders.Remove(existing);
        _appMyDbContext.SaveChanges();

        return true;
    }

    public Order? Get(int id)
    {
        return _appMyDbContext.Orders.Find(id);
    }

    public IList<Order> GetOrders() => _appMyDbContext.Orders.ToList();

    public bool Update(Order order)
    {
        var existing = _appMyDbContext.Orders.Find(order.Id);

        if (existing == null)
        {
            return false;
        }

        existing.OrderNbr = order.OrderNbr;
        existing.OrderDate = order.OrderDate;
        existing.Montant = order.Montant;
        existing.IsActive = order.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        _appMyDbContext.SaveChanges();

        return true;
    }
}