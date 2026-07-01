using AutoMapper;
using OrderManagement.Domain.Entities;
using OrderManagement.Infra;

namespace OrderManagement.Application.OrderItemsService;

public class OrderItemsServices : IOrderItemsService
{
    private readonly IMapper _mapper;
    private readonly IOrderItemsRepository _orderItemsRepository;

    public OrderItemsServices(IOrderItemsRepository orderItemsRepository, IMapper mapper)
    {
        _orderItemsRepository = orderItemsRepository;
        _mapper = mapper;
    }

    public OrderItemDto AddOrderItem(OrderItemDto orderItemDto)
    {
        var orderItem = _mapper.Map<OrderItems>(orderItemDto);
        var created = _orderItemsRepository.AddOrderItem(orderItem);

        return new OrderItemDto
        {
            Cle = created.Id,
            ProductId = created.ProductId,
            Qnt = created.Qnt,
            OrderId = created.OrderId
        };
    }

    public bool DeleteOrderItem(int id)
    {
        return _orderItemsRepository.Delete(id);
    }

    public OrderItemDto? GetOrderItem(int id)
    {
        var orderItem = _orderItemsRepository.Get(id);

        if (orderItem == null)
        {
            return null;
        }

        return new OrderItemDto
        {
            Cle = orderItem.Id,
            ProductId = orderItem.ProductId,
            Qnt = orderItem.Qnt,
            OrderId = orderItem.OrderId
        };
    }

    public List<OrderItemDto> GetOrderItems()
    {
        var list = _orderItemsRepository.GetOrderItems();

        return list.Select(orderItem => new OrderItemDto
        {
            Cle = orderItem.Id,
            ProductId = orderItem.ProductId,
            Qnt = orderItem.Qnt,
            OrderId = orderItem.OrderId
        }).ToList();
    }

    public bool UpdateOrderItem(int id, OrderItemDto orderItemDto)
    {
        var orderItem = _orderItemsRepository.Get(id);

        if (orderItem == null)
        {
            return false;
        }

        orderItem.ProductId = orderItemDto.ProductId;
        orderItem.Qnt = orderItemDto.Qnt;
        orderItem.OrderId = orderItemDto.OrderId;

        return _orderItemsRepository.Update(orderItem);
    }
}