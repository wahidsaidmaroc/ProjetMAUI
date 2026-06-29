using Microsoft.EntityFrameworkCore;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra
{
    public class ProductRepository : IProductRepository
    {
        private AppMyDbContext _appMyDbContext;

        public ProductRepository(AppMyDbContext appMyDbContext)
        {
            _appMyDbContext = appMyDbContext;
        }

        void Add (Product product)
        {
            
        }

        void Update(Product product)
        {
            _appMyDbContext.Update<Product>(product);
            _appMyDbContext.SaveChanges();
        }
        Product? Get(int id)
        {
            return _appMyDbContext.Find<Product>(id);
        }

        public   IList<Product> GetProducts() => _appMyDbContext.Products.ToList();

    }
}
