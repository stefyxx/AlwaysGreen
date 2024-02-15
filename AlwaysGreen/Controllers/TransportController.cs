using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using AlwaysGreen.Functions;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportController(TransportServices _transportServices) : ControllerBase
    {
        // GET: api/<TransportController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                List<Transport> loctions = _transportServices.GetAll();
                return Ok(loctions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<TransportController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<TransportController>
        [HttpPost("insert")]
        public IActionResult Post([FromBody] TransportRegisteredDTO t)
        {
            try
            {
                List<Emptybottle> emptybottles = new List<Emptybottle>();
                t.Emptybottles.ForEach(e => emptybottles.Add(e.ToDomain()));
                

                Transport data = _transportServices.Register(
                    emptybottles

                    );
                //TransportResultDTO result = Mappers.ToDTO(data);
                //return Created("ok", result);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }

        }

        // PUT api/<TransportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransportController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
