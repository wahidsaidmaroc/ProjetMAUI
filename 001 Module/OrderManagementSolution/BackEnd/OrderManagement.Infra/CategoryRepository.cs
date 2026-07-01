using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public class CategoryRepository : ICategoryRepository
{
    private AppMyDbContext _appMyDbContext;
    public CategoryRepository(AppMyDbContext appMyDbContext)
    {
        _appMyDbContext = appMyDbContext;
    }
    public Category AddCategory(Category category)
    {
        _appMyDbContext.Categories.Add(category);
        _appMyDbContext.SaveChanges();

        return category;
    }

    public bool Delete(int id)
    {
        var existing = _appMyDbContext.Categories.Find(id);

        if (existing == null)
        {
            return false;
        }

        _appMyDbContext.Categories.Remove(existing);
        _appMyDbContext.SaveChanges();

        return true;
    }

    public Category? Get(int id)
    {
        return _appMyDbContext.Categories.Find(id);
    }

    public IList<Category> GetCategories() => _appMyDbContext.Categories.ToList();

    public bool Update(Category category)
    {
        var existing = _appMyDbContext.Categories.Find(category.Id);

        if (existing == null)
        {
            return false;
        }

        existing.Name = category.Name;
        existing.Description = category.Description;
        existing.IsActive = category.IsActive;
        existing.UpdatedAt = DateTime.UtcNow;

        _appMyDbContext.SaveChanges();

        return true;
    }
}
