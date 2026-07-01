namespace OrderManagement.Application.CategoryService;

public interface ICategoryService
{
    CategoryDto? GetCategory(int id);
    List<CategoryDto> GetCategories();
    CategoryDto AddCategory(CategoryDto categoryDto);
    bool UpdateCategory(int id, CategoryDto categoryDto);
    bool DeleteCategory(int id);
}
