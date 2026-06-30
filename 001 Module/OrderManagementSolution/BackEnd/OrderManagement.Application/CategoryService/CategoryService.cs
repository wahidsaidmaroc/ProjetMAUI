using OrderManagement.Infra;

namespace OrderManagement.Application.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    #region "Add"


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


    public List<CategoryDto> GetCategories()
    {
        var list = _categoryRepository.GetCategories();


        List<CategoryDto> listRetdurn = new List<CategoryDto>();

        return listRetdurn;
    }

    #endregion
}