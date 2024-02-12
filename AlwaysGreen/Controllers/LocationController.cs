using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(LocationServices _locationServices) : ControllerBase
    {
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    try
        //    {

        //        List<Location> loctions = _locationServices.GetAll();
        //        return Ok(loctions);
        //    }
        //    catch (Exception ex) { return BadRequest(ex.Message); }
        //}
    }
}
