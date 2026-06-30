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

        private IPayementService _payementServices;
        public PayementController(IPayementService payementServices)
        {
            _payementServices = payementServices;
        }

        // GET: api/<PayementController>
        [HttpGet]
        public IEnumerable<PayementDto> Get() => _payementServices.GetPayements();

        // GET api/<PayementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PayementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PayementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PayementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
