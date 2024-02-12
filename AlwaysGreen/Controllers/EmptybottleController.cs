using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmptybottleController(EmptybottleServices _services) : ControllerBase
    {
        // GET: api/<EmptybottleController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmptybottleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EmptybottleController>
        [HttpPost("add")]
        public IActionResult Post([FromBody] UpdateEmptybottleDTO value)
        {
            try
            {
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<EmptybottleController>/5
        [HttpPut("{id}")] //--> anche x updatare le quantities
        public IActionResult Put(int id, [FromBody] UpdateEmptybottleDTO value)
        {
            try
            {
                Emptybottle? b = _services.Find(id);
                if (b.TypeName != value.TypeName) throw new Exception("L'id non corrisponde alla bottiglia che si vuole modifivare"); 
                else
                {
                    b.Quantity = value.Quantity;
                    b.Prix= value.Prix;
                    return Ok(_services.MyUpdate(b));   
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }

        // DELETE api/<EmptybottleController>/5
        //[HttpDelete("{id}")]
        //strong!
        [HttpDelete("delete")]
        public IActionResult Delete([FromBody]int id)
        {
            try
            {
                Emptybottle? bottle = _services.Find(id);
                if (bottle == null) throw new KeyNotFoundException();
                else
                {
                    _services.Delete(bottle);
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
