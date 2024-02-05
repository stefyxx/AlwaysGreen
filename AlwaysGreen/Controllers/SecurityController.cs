using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.DTO;
using AlwaysGreen.SecurityJWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AlwaysGreen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController(SecurityServices _securityService, JwtManager _jwtManager) : ControllerBase
    {
        [HttpPost]
        public IActionResult MyLogin([FromBody] LoginDTO dto)
        {
            try
            {
                //per arrivare alla mail bisogna risalire a Location AUT particular

                Login l = _securityService.Login(dto.Username, dto.Password);

            if(l.Roles.Any())
                {

                }
                // --> CreateToken (string username, string identifier, string email, params string[] roles)
                string token = _jwtManager.CreateToken(l.Email, l.Id.ToString(), l.Email, l.Roles.ToString());
                return Ok(new { Token = token });
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }

        }
    }
}
