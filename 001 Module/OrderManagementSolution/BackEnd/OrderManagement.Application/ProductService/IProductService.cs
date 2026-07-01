
namespace OrderManagement.Application.ProductService;

public interface IProductService
{
    ProductDto AddProduct(ProductDto productDto);
    bool DeleteProduct(int id);
    ProductDto? GetProduct(int id);
    List<ProductDto> GetProducts();
    bool UpdateProduct(int id, ProductDto productDto);
}
