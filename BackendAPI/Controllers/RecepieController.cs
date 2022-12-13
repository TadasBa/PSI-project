using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepieController : ControllerBase
    {
        private readonly ProductDBContext _dbContext;

        public RecepieController(ProductDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var recepie = await _dbContext.Recepies.ToListAsync();
            return recepie == null ? NotFound() : Ok(recepie);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var recepie = await _dbContext.Recepies.FindAsync(id);
            return recepie == null ? NotFound() : Ok(recepie);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateRecepie(Recepie recepie)
        {
            await _dbContext.Recepies.AddAsync(recepie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = recepie.Id }, recepie);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Recepie recepie)
        {
            if (id != recepie.Id) return BadRequest();

            _dbContext.Entry(recepie).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var recepie = await _dbContext.Recepies.FindAsync(id);
            if (recepie == null) return NotFound();

            _dbContext.Recepies.Remove(recepie);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
