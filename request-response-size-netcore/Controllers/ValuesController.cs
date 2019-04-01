using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderService2;
using request_response_size_netcore.Filters;

namespace request_response_size_netcore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [CustomFilter]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return new Order { CustomerName = "asdas", CustomerEmail = "test@gmail.com",OrderId=12312312 };
        }

        // POST api/values
        [HttpPost]
        public Order Post([FromBody] Order value)
        {

            return value;

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
