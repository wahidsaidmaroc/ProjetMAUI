using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.CategoryService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryServices = categoryService;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CategoryDto>> Get()
        {
            return Ok(_categoryServices.GetCategories());
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CategoryDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid id is required.");
            }

            var category = _categoryServices.GetCategory(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CategoryDto> Post([FromBody] CategoryDto value)
        {
            if (value == null)
            {
                return BadRequest("Payload is required.");
            }

            if (string.IsNullOrWhiteSpace(value.Name))
            {
                return BadRequest("Category name is required.");
            }

            var created = _categoryServices.AddCategory(value);
            return Created($"api/Category/{created.Cle}", created);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] CategoryDto value)
        {
            if (value == null || id <= 0)
            {
                return BadRequest("Valid id and payload are required.");
            }

            var updated = _categoryServices.UpdateCategory(id, value);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid id is required.");
            }

            var deleted = _categoryServices.DeleteCategory(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
