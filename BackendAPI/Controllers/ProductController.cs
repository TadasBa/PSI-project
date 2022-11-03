using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendAPI.Data;
using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDBContext _dbContext;

        public ProductController(ProductDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _dbContext.Products.ToListAsync();
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpGet("usrid")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByUsrId(int usrid)
        {
            var product = _dbContext.Products.Where(product => product.UsrID == usrid);
            return product == null ? NoContent() : Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new {id = product.Id}, product);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if(id != product.Id) return BadRequest();

            _dbContext.Entry(product).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var productToDelete = await _dbContext.Products.FindAsync(id);
            if(productToDelete == null) return NotFound();

            _dbContext.Products.Remove(productToDelete);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
