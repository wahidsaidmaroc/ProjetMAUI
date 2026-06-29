
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application;




public class ProductProfile //: Profile
{
    public ProductProfile()
    {
        // Entity → DTO
        //CreateMap<Product, ProductDto>()
        //    .ForMember(dest => dest.Cle, opt => opt.MapFrom(src => src.Id))
        //    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ProdDescription))
        //    .ForMember(dest => dest.Prix, opt => opt.MapFrom(src => src.UnitPrice));

        // DTO → Entity
        //CreateMap<ProductDto, Product>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Cle))
        //    .ForMember(dest => dest.ProdDescription, opt => opt.MapFrom(src => src.Description))
        //    .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Prix))
        //    .ForMember(dest => dest.ProdName, opt => opt.Ignore()) // ⚠️ obligatoire
        //    .ForMember(dest => dest.ProdCode, opt => opt.Ignore()); // facultatif
    }
}