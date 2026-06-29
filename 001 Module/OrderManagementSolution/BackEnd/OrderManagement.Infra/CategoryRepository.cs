using OrderManagement.Domain.Entities;

namespace OrderManagement.Infra;

public class CategoryRepository : ICategoryRepository
{
    private AppMyDbContext _appMyDbContext;
    public CategoryRepository(AppMyDbContext appMyDbContext)
    {
        _appMyDbContext = appMyDbContext;
    }
    public IList<Category> GetCategories() => _appMyDbContext.Categories.ToList();
}
