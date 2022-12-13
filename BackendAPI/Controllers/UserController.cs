using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BackendAPI.Controllers
{
    [Route("auth/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ProductDBContext _dBContext;

        public UserController(ProductDBContext context)
        {
            _dBContext = context;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> LogIn(User user)
        {
            var loggedin = _dBContext.Users.Where(u => u.Password == HashCode(user.Password) && u.Email == user.Email).FirstOrDefault();
            if (loggedin is not null) loggedin.Password = "N/A";
            return loggedin == null ? NotFound() : Ok(loggedin);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(User user)
        {
            if(_dBContext.Users.Where(u => u.Email == user.Email).Any())
            {
                return Conflict(user);
            }

            user.Password = HashCode(user.Password);
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
        }

        [HttpPut("user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, User user)
        {
            if (id != user.Id) return BadRequest();
            
            var usr = await _dBContext.Users.FindAsync(id);

            if (user.Password != "N/A") usr.Password = HashCode(user.Password);
            usr.Name = user.Name;
            usr.Email = user.Email;
            _dBContext.Entry(usr).State = EntityState.Modified;
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Delete(int id)
        {
            var userToDelete = await _dBContext.Users.FindAsync(id);
            if (userToDelete == null) return NotFound();

            _dBContext.Users.Remove(userToDelete);
            await _dBContext.SaveChangesAsync();

            return Ok();
        }

        [ActionName(nameof(Get))]
        private async Task<IActionResult> Get(int id)
        {
            var product = await _dBContext.Users.FindAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        public string HashCode(string password)
        {
            var passBytes = Encoding.Default.GetBytes(password);

            SHA256 hash = SHA256.Create();
            hash.ComputeHash(passBytes);

            return Convert.ToBase64String(passBytes);
        }
    }
}
