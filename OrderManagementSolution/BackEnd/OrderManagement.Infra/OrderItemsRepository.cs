using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public class OrderItemsRepository : IOrderItemsRepository
{
    private readonly AppMyDbContext _appMyDbContext;

    public OrderItemsRepository(AppMyDbContext appMyDbContext)
    {
        _appMyDbContext = appMyDbContext;
    }

    public OrderItems AddOrderItem(OrderItems orderItem)
    {
        _appMyDbContext.OrderItems.Add(orderItem);
        _appMyDbContext.SaveChanges();

        return orderItem;
    }

    public bool Delete(int id)
    {
        var existing = _appMyDbContext.OrderItems.Find(id);

        if (existing == null)
        {
            return false;
        }

        _appMyDbContext.OrderItems.Remove(existing);
        _appMyDbContext.SaveChanges();

        return true;
    }

    public OrderItems? Get(int id)
    {
        return _appMyDbContext.OrderItems.Find(id);
    }

    public IList<OrderItems> GetOrderItems() => _appMyDbContext.OrderItems.ToList();

    public bool Update(OrderItems orderItem)
    {
        var existing = _appMyDbContext.OrderItems.Find(orderItem.Id);

        if (existing == null)
        {
            return false;
        }

        existing.ProductId = orderItem.ProductId;
        existing.Qnt = orderItem.Qnt;
        existing.OrderId = orderItem.OrderId;
        existing.IsActive = orderItem.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        _appMyDbContext.SaveChanges();

        return true;
    }
}