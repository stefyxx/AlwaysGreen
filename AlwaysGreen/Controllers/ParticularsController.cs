using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using AlwaysGreen.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

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

                ParticularResultDTO result = Mappers.ToDTO(data);
                return Created("ok", result);
                //return Ok();
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


        // PUT api/<ParticularsController>/5  --> [HttpPut("{id}")]
        [HttpPut]
        [Authorize(Roles = "Particular")]
        public IActionResult Update([FromBody] UpdateParticularDTO updateDTO, [FromQuery]string cancelLink)
        {
            bool isConnected = User != null;
            if (isConnected)
            {
                //se user esiste realmente in in BD
                var userId = User.FindFirst(ClaimTypes.NameIdentifier);
                Particular? p = _particularServices.Find(int.Parse(userId.Value));
                if (p != null)
                {
                    Address newAddress = new Address() 
                    { 
                        Id= p.AddressId,
                        StreetName = updateDTO.Address.StreetName,
                        StreetNumber = updateDTO.Address.StreetNumber,
                        Apartment = updateDTO.Address.Apartment ?? null,
                        Unit = updateDTO.Address.Unit ?? null,
                        UnitNumber = updateDTO.Address.UnitNumber ?? null,
                        City = updateDTO.Address.City,
                        ZipCode = updateDTO.Address.ZipCode,
                        Country = updateDTO.Address.Country
                    };
                    //posso updatare i valori ricevuto nel Body della request: 
                    Particular? updatedUser = _particularServices.myUpdate(
                        p, updateDTO.Username, updateDTO.Email, newAddress, updateDTO.PhoneNumber, updateDTO.Password, cancelLink);

                    return Ok(updatedUser);
                }else throw new Exception("No user found");
            }
            else return Unauthorized();
        }

        // DELETE api/<ParticularsController>/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Particular")]
        public void Delete(int id)
        {

        }
    }
}
