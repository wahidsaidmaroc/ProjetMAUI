using AutoMapper;
using OrderManagement.Domain.Entities;
using OrderManagement.Infra;

namespace OrderManagement.Application.OrderService;

public class OrderServices : IOrderService
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderServices(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public OrderDto AddOrder(OrderDto orderDto)
    {
        var order = _mapper.Map<Order>(orderDto);
        var created = _orderRepository.AddOrder(order);

        return new OrderDto
        {
            Cle = created.Id,
            OrderNbr = created.OrderNbr,
            OrderDate = created.OrderDate,
            Montant = created.Montant
        };
    }

    public bool DeleteOrder(int id)
    {
        return _orderRepository.Delete(id);
    }

    public OrderDto? GetOrder(int id)
    {
        var order = _orderRepository.Get(id);

        if (order == null)
        {
            return null;
        }

        return new OrderDto
        {
            Cle = order.Id,
            OrderNbr = order.OrderNbr,
            OrderDate = order.OrderDate,
            Montant = order.Montant
        };
    }

    public List<OrderDto> GetOrders()
    {
        var list = _orderRepository.GetOrders();

        return list.Select(order => new OrderDto
        {
            Cle = order.Id,
            OrderNbr = order.OrderNbr,
            OrderDate = order.OrderDate,
            Montant = order.Montant
        }).ToList();
    }

    public bool UpdateOrder(int id, OrderDto orderDto)
    {
        var order = _orderRepository.Get(id);

        if (order == null)
        {
            return false;
        }

        order.OrderNbr = orderDto.OrderNbr == 0 ? id : orderDto.OrderNbr;
        order.OrderDate = orderDto.OrderDate;
        order.Montant = orderDto.Montant;

        return _orderRepository.Update(order);
    }
}