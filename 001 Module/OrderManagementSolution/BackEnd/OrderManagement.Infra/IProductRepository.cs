using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public interface IProductRepository
    {
        public IList<Product> GetProducts();
    }
}
