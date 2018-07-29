using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductPropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductProperties
        [HttpGet]
        public IEnumerable<ProductProperty> GetProductProperties()
        {
            return _context.ProductProperties;
        }

        // GET: api/ProductProperties/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productProperty = await _context.ProductProperties.FindAsync(id);

            if (productProperty == null)
            {
                return NotFound();
            }

            return Ok(productProperty);
        }

        // PUT: api/ProductProperties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProperty([FromRoute] int id, [FromBody] ProductProperty productProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productProperty.Id)
            {
                return BadRequest();
            }

            _context.Entry(productProperty).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductPropertyExists(id))
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

        // POST: api/ProductProperties
        [HttpPost]
        public async Task<IActionResult> PostProductProperty([FromBody] ProductProperty productProperty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.ProductProperties.Add(productProperty);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductProperty", new { id = productProperty.Id }, productProperty);
        }

        // DELETE: api/ProductProperties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductProperty([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var productProperty = await _context.ProductProperties.FindAsync(id);
            if (productProperty == null)
            {
                return NotFound();
            }

            _context.ProductProperties.Remove(productProperty);
            await _context.SaveChangesAsync();

            return Ok(productProperty);
        }

        private bool ProductPropertyExists(int id)
        {
            return _context.ProductProperties.Any(e => e.Id == id);
        }
    }
}