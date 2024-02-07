using AlwaysGreen.BLL.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticularsController(ParticularServices _particularServices) : ControllerBase
    {
        // GET: api/<ParticularsController>
        [HttpGet]
        public IActionResult Get()
        {
            //getAll
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // GET api/<ParticularsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ParticularsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ParticularsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParticularsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
