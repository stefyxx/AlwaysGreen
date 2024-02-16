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
                List<Location> datas = _locationServices.GetAll();
                List< LocationResultDTO > result = datas.Select(Mappers.ToDTO).ToList();
                return Ok(result);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("insert")]
        public IActionResult Post([FromBody] LocationRegisteredDTO l)
        {
            try
            {
                Location data = _locationServices.Register(
                    l.AgencyName, l.CompanyName,
                    l.PhoneNumber, l.Roles, l.Email,
                    Mappers.ToDomain(l.Address),
                    l.Password, l.Username,
                    l.VATnumber, Mappers.ToDomain(l.Siret),
                    l.IsPickUpPoint,
                    l.IsStorePoint
                    );
                LocationResultDTO result = Mappers.ToDTO(data);
                return Created("ok", result);
            }
            catch (ValidationException ex) { return BadRequest(ex.Message); }
        }
    }
}
