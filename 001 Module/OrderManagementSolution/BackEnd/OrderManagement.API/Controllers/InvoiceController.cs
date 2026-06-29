using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private IInvoiceService _InvoiceServices;
        public InvoiceController(IInvoiceService InvoiceService)
        {
            _InvoiceServices = InvoiceService;
        }

        // GET: api/<InvoiceController>
        [HttpGet]
        public IEnumerable<InvoiceDto> Get() => _InvoiceServices.GetInvoices();

        // GET api/<InvoiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<InvoiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<InvoiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InvoiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
