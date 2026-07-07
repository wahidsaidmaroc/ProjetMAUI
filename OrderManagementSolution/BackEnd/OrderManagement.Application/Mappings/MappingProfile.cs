using AutoMapper;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Cle, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProdName))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProdDescription))
            .ForMember(dest => dest.Prix, opt => opt.MapFrom(src => src.UnitPrice));
        CreateMap<ProductDto, Product>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Cle))
            .ForMember(dest => dest.ProdName, opt => opt.MapFrom(src => src.Name ?? string.Empty))
            .ForMember(dest => dest.ProdDescription, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Prix));

        CreateMap<Order, OrderDto>()
            .ForMember(dest => dest.OrderNbr, opt => opt.MapFrom(src => src.OrderNbr))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.Montant, opt => opt.MapFrom(src => src.Montant));
        CreateMap<OrderDto, Order>()
            .ForMember(dest => dest.OrderNbr, opt => opt.MapFrom(src => src.OrderNbr))
            .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.OrderDate))
            .ForMember(dest => dest.Montant, opt => opt.MapFrom(src => src.Montant));

        CreateMap<OrderItems, OrderItemDto>()
            .ForMember(dest => dest.Cle, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Qnt, opt => opt.MapFrom(src => src.Qnt))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));
        CreateMap<OrderItemDto, OrderItems>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Cle))
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Qnt, opt => opt.MapFrom(src => src.Qnt))
            .ForMember(dest => dest.OrderId, opt => opt.MapFrom(src => src.OrderId));
    }
}
