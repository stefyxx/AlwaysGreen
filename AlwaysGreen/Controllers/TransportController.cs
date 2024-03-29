﻿

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
                List<Transport> datas = _transportServices.GetAll();
                List<TransportResultDTO> result = datas.Select(Mappers.ToDTO).ToList();
                return Ok(result);
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
        //[Authorize(Roles = "Depot")]
        public IActionResult Post([FromBody] TransportRegisteredDTO t)
        {
            try
            {
                //TODO: optimize the code --> separate function
                List<Emptybottle> emptybottles = new List<Emptybottle>();
                t.Emptybottles.ForEach(eB =>
                {
                    if (eB.Quantity > 0)
                    {
                        emptybottles.Add(eB.ToDomain());
                    }
                    else throw new ArgumentOutOfRangeException("It's impossible to add a negative quantity!");
                });
                if (emptybottles.Count == 0) throw new Exception("It is impossible to organize transport if you don't have empty bottles to transport!");

                Transport data = _transportServices.Register(emptybottles, t.LocationFromId,t.LocationToId, t.CourierId);
                TransportResultDTO result = Mappers.ToDTO(data);
                return Created("ok", result);

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
