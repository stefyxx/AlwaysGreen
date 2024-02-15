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
        public IActionResult Post([FromBody] ParticularRegisteredDTO d)
        {
            //registered a particular --> return void, ma io voglio un IActionResult che mi da ok se creato
            try
            {
                Particular data = _particularServices.Register(
                    d.FirstName,d.LastName,d.PhoneNumber, d.Email, 
                    Mappers.ToDomain(d.Address), d.Password, d.Username);

                ParticularResultDTO result = Mappers.ToDTO(data);
                return Created("ok", result);
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
        [HttpPut("Delete")]
        //[Authorize]
        [Authorize(Roles = "Particular")]
        public IActionResult Update([FromBody] ParticularUpdateDTO updateDTO, [FromQuery]string? cancelLink)
        {
            bool isConnected = User != null;
            if (isConnected)
            {
                //string? email = User.FindFirstValue(ClaimTypes.Email);

                //se user esiste realmente in in BD
                int loginId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                Address newAddress = new Address()
                {
                    StreetName = updateDTO.Address.StreetName,
                    StreetNumber = updateDTO.Address.StreetNumber,
                    Apartment = updateDTO.Address.Apartment ?? null,
                    Unit = updateDTO.Address.Unit ?? null,
                    UnitNumber = updateDTO.Address.UnitNumber ?? null,
                    City = updateDTO.Address.City,
                    ZipCode = updateDTO.Address.ZipCode,
                    Country = updateDTO.Address.Country
                };
                Particular? p = _particularServices.FirstUpdate(loginId, newAddress);
                if (p != null || p.IsActive == true)
                {
                    //posso updatare i valori ricevuto nel Body della request: 
                    Particular? updatedUser = _particularServices.myUpdate(
                        p, updateDTO.Username, updateDTO.Email, p.AddressId, updateDTO.PhoneNumber, updateDTO.Password, cancelLink);
                    ParticularResultDTO pNew = Mappers.ToDTO(updatedUser);

                    return Ok(pNew);
                }else throw new Exception("No user found"); // o perché non esiste o perché é stato già 'cancellato'
            }
            else return Unauthorized();
        }

        // DELETE api/<ParticularsController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Particular")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            bool isConnected = User != null;
            if (isConnected)
            {

                int loginId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                Particular? p = _particularServices.FindWithLoginId(loginId);
                if(id == p.Id)
                {
                    p.IsActive = false;
                    _particularServices.Update(p);
                    return Ok();
                }
                else return Unauthorized(); // perché chiedo di cancellare una persona diversa dalla loggata

            }
            else return Unauthorized();
        }
    }
}
