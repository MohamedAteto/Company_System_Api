using System.Formats.Asn1;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Company_System_Api.DTOs.AuthDTOs;
using Company_System_Api.Mapping;
using Company_System_Api.Models;
using Company_System_Api.Reposatories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Company_System_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration config, IUnitOfWork unit)
        {
            _config = config;
            _unit = unit;
            _mapper = new MapperConfiguration(c => c.AddProfile<MappingProfiles>()).CreateMapper();
        }

        [HttpPost("login")] 
        public async Task<IActionResult> Login(LoginDTO DTO)
        {
            if(DTO is null)
                return BadRequest("Invalid client request");

            var item =  await _unit.Users.GetByUserName(DTO.Username);

            if(item is null)
                return NotFound("User not found");

            if (item.Password != DTO.Password)
                return Unauthorized("Invalid password");

            var token = CreateToken(item);

            return Ok( token );

        }

        private string CreateToken(User user)
        {


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);



            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };



            var token = new JwtSecurityToken(

                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
