using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using AlwaysGreen.Functions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(LocationServices _locationServices) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {

                List<Location> loctions = _locationServices.GetAll();
                return Ok(loctions);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("insert")]
        public IActionResult Post([FromBody]RegisteredLocationDTO l)
        {
            try
            {
                //forse avro' problemi con roles --> mapper

                Location data = _locationServices.Register(
                    l.AgencyName, l.CompanyName,
                    l.PhoneNumber,l.Roles, l.Email,
                    Mappers.ToDomain(l.Address), 
                    l.Password, l.Username,
                    l.VATnumber, Mappers.ToDomain(l.Siret),
                    l.IsPickUpPoint,
                    l.IsStorePoint
                    );
                //LocationResultDTO result = Mappers.
                //return Created("ok", result);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }
    }
}
