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

        public Product AddProduct(Product product)
        {
            _appMyDbContext.Products.Add(product);
            _appMyDbContext.SaveChanges();

            return product;
        }

        public bool Update(Product product)
        {
            var existing = _appMyDbContext.Products.Find(product.Id);

            if (existing == null)
            {
                return false;
            }

            existing.ProdCode = product.ProdCode;
            existing.ProdName = product.ProdName;
            existing.ProdDescription = product.ProdDescription;
            existing.UnitPrice = product.UnitPrice;

            _appMyDbContext.SaveChanges();

            return true;
        }

        public Product? Get(int id)
        {
            return _appMyDbContext.Find<Product>(id);
        }

        public bool Delete(int id)
        {
            var existing = _appMyDbContext.Products.Find(id);

            if (existing == null)
            {
                return false;
            }

            _appMyDbContext.Products.Remove(existing);
            _appMyDbContext.SaveChanges();

            return true;
        }

        public IList<Product> GetProducts() => _appMyDbContext.Products.ToList();

    }
}
