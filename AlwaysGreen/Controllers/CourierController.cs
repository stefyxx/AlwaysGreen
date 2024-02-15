using AlwaysGreen.BLL.Infrastructs;
using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
using AlwaysGreen.DTO;
using AlwaysGreen.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourierController (CourierServices _courierServices) : ControllerBase
    {
        // GET: api/<CourierController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Courier> datas = _courierServices.GetAll();
                //creare un DTO senno' entra in cilco x Address
                //Select(Mappers.ToDTO) --> posso scriverlo direttamente perché ho messo THIS
                List<CourierResultDTO> result = datas.Select(Mappers.ToDTO).ToList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //// GET api/<CourierController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<CourierController>
        [HttpPost("insert")]
        //[Authorize(Roles = "Depot")]
        public IActionResult Post([FromBody] CourierDTO c)
        {
            try
            {
                Courier data = _courierServices.Register(c.Name, c.PhoneNumber, c.Email, c.VATnumber, Mappers.ToDomain(c.Address));
                CourierResultDTO resul = Mappers.ToDTO(data);
                return Created("ok", resul);
                //return CreatedAtRoute("route del tuo catalogo", new { resul.Id },resul)
            }
            catch { return BadRequest(); };

        }

        // PUT api/<CourierController>/5
        [HttpPut("update/{id}")]
        [Authorize(Roles = "Depot")]
        public IActionResult Update([FromQuery]int? idRoute, [FromBody] CourierResultDTO c)
        {
            //int loginId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                Courier? updatedC= _courierServices.MyUpdate(idRoute, c.Id, c.Name, c.PhoneNumber, c.Email, c.VATnumber, Mappers.ToDomain(c.Address));
                CourierDTO cUpdated = Mappers.ToDTO(updatedC);
                return Ok(cUpdated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("Delete/{id}")]
        [Authorize(Roles = "Depot")]
        public IActionResult Put([FromQuery] int id)
        {
            try
            {
                _courierServices.Delete(id);
                return Ok();
            }
            catch(Exception ex)
            {
                
                return NotFound(ex.Message);
            }
        }
        //// DELETE api/<CourierController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
