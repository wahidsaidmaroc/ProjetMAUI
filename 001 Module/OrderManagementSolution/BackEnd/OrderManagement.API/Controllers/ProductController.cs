using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.ProductService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productServices;
        public ProductController(IProductService productService)
        {
            _productServices = productService;
        }

        // GET: api/Product
        [HttpGet]
        [ProducesResponseType(typeof(IList<ProductDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IList<ProductDto>> Get()
        {
            var list = _productServices.GetProducts();

            if (list == null || list.Count == 0)
            {
                return NoContent();
            }

            return Ok(list);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProductDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid id is required.");
            }

            var product = _productServices.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        [ProducesResponseType(typeof(ProductDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductDto> Post([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Payload is required.");
            }

            if (string.IsNullOrWhiteSpace(productDto.Name))
            {
                return BadRequest("Product name is required.");
            }

            var created = _productServices.AddProduct(productDto);
            return Created($"api/Product/{created.Cle}", created);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] ProductDto value)
        {
            if (value == null || id <= 0)
            {
                return BadRequest("Valid id and payload are required.");
            }

            if (value.Cle != 0 && value.Cle != id)
            {
                return BadRequest("Payload id must match route id.");
            }

            var updated = _productServices.UpdateProduct(id, value);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<ProductController>/5
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

            var deleted = _productServices.DeleteProduct(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
