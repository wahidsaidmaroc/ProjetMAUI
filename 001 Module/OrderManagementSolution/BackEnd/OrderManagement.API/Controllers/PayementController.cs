using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.PayementService;
using OrderManagement.Application.ProductService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementController : ControllerBase
    {

        private readonly IPayementService _payementServices;
        public PayementController(IPayementService payementServices)
        {
            _payementServices = payementServices;
        }

        // GET: api/<PayementController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PayementDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<PayementDto>> Get()
        {
            return Ok(_payementServices.GetPayements());
        }

        // GET api/<PayementController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PayementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<PayementDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid id is required.");
            }

            var payement = _payementServices.GetPayement(id);

            if (payement == null)
            {
                return NotFound();
            }

            return Ok(payement);
        }

        // POST api/<PayementController>
        [HttpPost]
        [ProducesResponseType(typeof(PayementDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<PayementDto> Post([FromBody] PayementDto value)
        {
            if (value == null)
            {
                return BadRequest("Payload is required.");
            }

            if (string.IsNullOrWhiteSpace(value.DatePayement))
            {
                return BadRequest("Payment date is required.");
            }

            if (!DateTime.TryParse(value.DatePayement, out _))
            {
                return BadRequest("Payment date is invalid.");
            }

            var created = _payementServices.AddPayement(value);
            return Created($"api/Payement/{created.PaymentNbr}", created);
        }

        // PUT api/<PayementController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] PayementDto value)
        {
            if (value == null || id <= 0)
            {
                return BadRequest("Valid id and payload are required.");
            }

            if (!string.IsNullOrWhiteSpace(value.DatePayement) && !DateTime.TryParse(value.DatePayement, out _))
            {
                return BadRequest("Payment date is invalid.");
            }

            var updated = _payementServices.UpdatePayement(id, value);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<PayementController>/5
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

            var deleted = _payementServices.DeletePayement(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
