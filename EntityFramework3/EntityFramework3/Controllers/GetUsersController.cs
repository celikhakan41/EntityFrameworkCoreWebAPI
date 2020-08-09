using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityFramework3.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using EntityFramework3.Models.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace EntityFramework3.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]


    public class GetUsersController : ControllerBase
    {
       
       
        private readonly EfCoreContext _efcc;
        public GetUsersController(EfCoreContext efCore) {

            _efcc = efCore;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetProducts()
        {
            return await _efcc.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetProducts(int id)
        {
            var users = await _efcc.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User userDto)
        {
            _efcc.Users.Add(userDto);
            await _efcc.SaveChangesAsync();


            return CreatedAtAction("Get", new { id = userDto.UserId }, userDto);
        }
        //GetUsers controller gayet iyi çalışıyor problemin token controller da oldugunu düşünüyorum ilk if den ileriye gidemiyor

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User userDto)
        {
            if (id != userDto.UserId)
            {
                return BadRequest();
            }

            _efcc.Entry(userDto).State = EntityState.Modified;

            try
            {
                await _efcc.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            var users = await _efcc.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _efcc.Users.Remove(users);
            await _efcc.SaveChangesAsync();

            return users;
        }
        private bool UserExists(int id)
        {
            return _efcc.Users.Any(e => e.UserId == id);
        }

    }

}
