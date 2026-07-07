using OrderManagement.Domain.Entities;
namespace OrderManagement.Infra;
public interface ICategoryRepository
{
    public Category AddCategory(Category category);
    public bool Delete(int id);
    public Category? Get(int id);
    public IList<Category> GetCategories();
    public bool Update(Category category);
}
