using AutoMapper;
using OrderManagement.Infra;

namespace OrderManagement.Application.ProductService;

public class InvoiceServices : IProductService
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    public InvoiceServices(IProductRepository productRepository, 
        IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }





    #region "Add"


    public ProductDto AddProduct(ProductDto productDto)
    {
        var product = _mapper.Map<OrderManagement.Domain.Entities.Product>(productDto);
        var created = _productRepository.AddProduct(product);

        return _mapper.Map<ProductDto>(created);
    }

    public bool UpdateProduct(int id, ProductDto productDto)
    {
        var existing = _productRepository.Get(id);

        if (existing == null)
        {
            return false;
        }

        existing.ProdName = productDto.Name ?? string.Empty;
        existing.ProdDescription = productDto.Description;
        existing.UnitPrice = productDto.Prix;

        return _productRepository.Update(existing);
    }

    public bool DeleteProduct(int id)
    {
        return _productRepository.Delete(id);
    }


    public void AddProductByAdmin()
    {
        
    }

    public void AddProductByUser()
    {

    }

    public void AddProductByOperator()
    {

    }


    #endregion


    #region "Read"

    public ProductDto? GetProduct(int id)
    {
        var product = _productRepository.Get(id);

        if (product == null)
        {
            return null;
        }

        return _mapper.Map<ProductDto>(product);
    }


    public List<ProductDto> GetProducts()
    {
        var list = _productRepository.GetProducts();

        return _mapper.Map<List<ProductDto>>(list);
    }
        



    



    #endregion
}
