using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;
using OrderManagement.Application.invoice;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceServices;
        public InvoiceController(IInvoiceService InvoiceService)
        {
            _invoiceServices = InvoiceService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InvoiceDto>), StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<InvoiceDto>> Get()
        {
            return Ok(_invoiceServices.GetInvoices());
        }

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<InvoiceDto> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Valid id is required.");
            }

            var invoice = _invoiceServices.GetInvoice(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return Ok(invoice);
        }

        // POST api/<InvoiceController>
        [HttpPost]
        [ProducesResponseType(typeof(InvoiceDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<InvoiceDto> Post([FromBody] InvoiceDto value)
        {
            if (value == null)
            {
                return BadRequest("Payload is required.");
            }

            if (value.DtInvoice == default)
            {
                return BadRequest("Invoice date is required.");
            }

            var created = _invoiceServices.AddInvoice(value);
            return Created($"api/Invoice/{created.KeyInvoice}", created);
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Put(int id, [FromBody] InvoiceDto value)
        {
            if (value == null || id <= 0)
            {
                return BadRequest("Valid id and payload are required.");
            }

            var updated = _invoiceServices.UpdateInvoice(id, value);

            if (!updated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE api/<InvoiceController>/5
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

            var deleted = _invoiceServices.DeleteInvoice(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
