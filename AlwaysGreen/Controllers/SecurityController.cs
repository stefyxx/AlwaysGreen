using AlwaysGreen.BLL.Services;
using AlwaysGreen.Domain.Entities;
using AlwaysGreen.Domain.Enums;
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
                Login l = _securityService.Login(dto.Username, dto.Password);

                string email;
                //if (l.Particular != null) email = l.Particular.Email;
                //else email = l.Depot.Email;

                if (l.Roles.Contains(RolesEnum.Particular)) email = l.Particular.Email;
                else email = l.Depot.Email;

                // --> CreateToken (string username, string identifier, string email, params string[] roles)
                string token = _jwtManager.CreateToken(l.Username, l.Id.ToString(), email, l.Roles.ToString());

                return Ok(new { Token = token });
                
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }

        }
    }
}
