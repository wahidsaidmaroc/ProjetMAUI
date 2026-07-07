using OrderManagement.Infra;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    #region "Add"

    public CategoryDto AddCategory(CategoryDto categoryDto)
    {
        var category = new Category
        {
            Name = categoryDto.Name,
            Description = categoryDto.Description
        };

        var created = _categoryRepository.AddCategory(category);

        return new CategoryDto
        {
            Cle = created.Id,
            Name = created.Name,
            Description = created.Description ?? string.Empty
        };
    }


    public void AddCategoryByAdmin()
    {
        
    }

    public void AddCategoryByUser()
    {

    }

    public void AddCategoryByOperator()
    {

    }


    #endregion

    #region "Read"

    public CategoryDto? GetCategory(int id)
    {
        var category = _categoryRepository.Get(id);

        if (category == null)
        {
            return null;
        }

        return new CategoryDto
        {
            Cle = category.Id,
            Name = category.Name,
            Description = category.Description ?? string.Empty
        };
    }


    public List<CategoryDto> GetCategories()
    {
        var list = _categoryRepository.GetCategories();

        return list
            .Select(category => new CategoryDto
            {
                Cle = category.Id,
                Name = category.Name,
                Description = category.Description ?? string.Empty
            })
            .ToList();
    }

    public bool UpdateCategory(int id, CategoryDto categoryDto)
    {
        var category = _categoryRepository.Get(id);

        if (category == null)
        {
            return false;
        }

        category.Name = categoryDto.Name;
        category.Description = categoryDto.Description;

        return _categoryRepository.Update(category);
    }

    public bool DeleteCategory(int id)
    {
        return _categoryRepository.Delete(id);
    }

    #endregion
}