using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BackendAPI.Controllers
{
    [Route("auth/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LogIn(User user)
        {
            var loggedin = _dBContext.Users.Where(u => u.Password == HashCode(user.Password) && u.Name == user.Name);
            return loggedin == null ? NoContent() : Ok(loggedin);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> Register(User user)
        {
            if(_dBContext.Users.Where(u => u.Email == user.Email).Count() > 0)
            {
                return Conflict(user);
            }

            user.Password = HashCode(user.Password);
            await _dBContext.Users.AddAsync(user);
            await _dBContext.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new {id = user.Id}, user);
        }

        private async Task<IActionResult> Get(int id)
        {
            var product = await _dBContext.Users.FindAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        private string HashCode(string password)
        {
            var passBytes = Encoding.Default.GetBytes(password);

            SHA256 hash = SHA256.Create();
            hash.ComputeHash(passBytes);

            return Convert.ToBase64String(passBytes);
        }
    }
}
