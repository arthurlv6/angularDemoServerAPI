using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using AutoMapper;
using Microsoft.Extensions.Logging;
using MediatR;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProductsController : BaseController
    {
        
        private ILogger<ProductsController> _logger;
        public ProductsController(
            IMediator mediator,
            IMapper mapper,
            ILogger<ProductsController> logger) : base( mapper, mediator)
        {
            _logger = logger;
        }
        /*
        // GET: api/Products
        [HttpGet]
        public IActionResult GetProducts(string name = null, int pageNumber = 1, int pageSize = 15)
        {
            //return _context.Products;
            Expression<Func<Product, bool>> searchName;

            if (string.IsNullOrEmpty(name))
            {
                searchName = d => true;
            }
            else
            {
                searchName = d => d.Name.Contains(name);
            }
            var entities =_context.Products.Where(searchName)
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Include(d => d.ProductCategory)
                .Include(d => d.ProductImages)
                .Include(d => d.ProductProperties)
                .Include(d => d.Supplier)
                .ToList();
            return Ok(_mapper.Map<IEnumerable<ProductModel>>(entities));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductModel>(product));
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] ProductModel model)
        {

            var entity = _context.Products.FirstOrDefault(d => d.Id == model.Id);
            if (entity == null)
                return NotFound();
            _mapper.Map(model, entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] ProductModel model)
        {
            var entity = _mapper.Map<Product>(model);

            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = entity.Id }, entity);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(product);
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
        */
    }
}