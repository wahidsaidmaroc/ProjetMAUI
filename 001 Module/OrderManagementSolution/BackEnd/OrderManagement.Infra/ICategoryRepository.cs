using OrderManagement.Domain.Entities;
namespace OrderManagement.Infra;
public interface ICategoryRepository
{
    public IList<Category> GetCategories();
}
