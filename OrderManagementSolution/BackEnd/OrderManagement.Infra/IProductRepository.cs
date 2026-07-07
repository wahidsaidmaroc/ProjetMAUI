using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public interface IProductRepository
    {
        public Product AddProduct(Product product);
        public bool Delete(int id);
        public Product? Get(int id);
        public IList<Product> GetProducts();
        public bool Update(Product product);
    }
}
