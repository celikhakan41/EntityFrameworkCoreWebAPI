using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFramework3.Models;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using EntityFramework3.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly EfCoreContext _context;

        public TokenController(IConfiguration config, EfCoreContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User _userData)
        {
            if (_userData != null && _userData.UserId != _userData.UserId && _userData.Password != null)
            {
                var user = await GetUser(_userData.UserId, _userData.Password);
                if (user != null)
                {
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserId", user.UserId.ToString()),
                    new Claim("Username", user.Username),
                    new Claim("Email", user.Email),
                    new Claim("Password", user.Password.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("MiddleName", user.MiddleName),
                    new Claim("DisplayName", user.DisplayName),
                    new Claim("BirthDate", user.BirthDate.ToString()),
                    new Claim("Gender", user.Gender.ToString()),
                    new Claim("WorkStart", user.WorkStart.ToString()),
                    new Claim("WorkEnd", user.WorkEnd.ToString()),
                    new Claim("Status", user.Status.ToString()),
                    new Claim("Type", user.Type.ToString()),
                    new Claim("DepartmentId", user.DepartmentId.ToString()),
                    new Claim("TitleId", user.TitleId.ToString()),
                    new Claim("ManagerUserId", user.ManagerUserId.ToString()),
                    new Claim("Language", user.Language),
                    new Claim("TimeZone", user.TimeZone.ToString()),
                    new Claim("Culture", user.Culture),
                    new Claim("Picture", user.Picture)
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Geçersiz Giriş - Invalid Login");
                }
            }
            else
            {
                return BadRequest();
            }

        }
        private async Task<User> GetUser(int id, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id && u.Password == password);
        }
    }
}
