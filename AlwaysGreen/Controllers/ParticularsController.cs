using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using AlwaysGreen.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
                //cerca di avere la lista:
                List<Particular> datas = _particularServices.GetAll();
                List<ParticularResultDTO> result = datas.Select(Mappers.ToDTO).ToList();

                //if(result.Count <= 0) { result = []; } //not necessary
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        // POST api/<ParticularsController>
        [HttpPost]
        public IActionResult Post([FromBody] RegisteredParticularDTO d)
        {
            //registered a particular --> return void, ma io voglio un IActionResult che mi da ok se creato
            try
            {
                Particular data = _particularServices.Register(
                    d.FirstName,d.LastName,d.PhoneNumber, d.Email, 
                    Mappers.ToDomain(d.Address), d.Password, d.Username);

                //ParticularResultDTO result = data.Select(Mappers.ToDTO);
                //return Created("ok", result);
                return Ok();
            }
            catch (ValidationException ex) 
            {
                return BadRequest(ex.Message);
            }

        }


        // GET api/<ParticularsController>/5
        [HttpGet("{id}")]
        //[Authorize(Roles = "Particular")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<ParticularsController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Particular")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ParticularsController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Particular")]
        public void Delete(int id)
        {
        }
    }
}
