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
                string token = _jwtManager.CreateToken(l.Username, l.Id.ToString(), email, l.Roles.Select(r => r.ToString()).ToArray());
                // property = RolesEnum[] --> l.Roles.Select(r => r.ToString()).ToArray()
                //property = RolesEnum; ossia non ho un array di RolesEnum, ma solo 1 rolesEnum  --> l.Roles.ToString()
                return Ok(new { Token = token });
                
            }
            catch (ValidationException)
            {
                return BadRequest("Invalid Credentials");
            }

        }
    }
}
