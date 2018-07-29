using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;
using WebAPI.Filters;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    //[Authorize]
    public class SuppliersController : BaseController
    {
        private ILogger<SuppliersController> _logger;
        public SuppliersController(
            ApplicationDbContext context,
            IMapper mapper,
            ILogger<SuppliersController> logger) : base(context,mapper)
        {
            _logger = logger;
        }
        // GET: api/Suppliers
        [HttpGet]
        public IEnumerable<SupplierModel> GetSuppliers(string name = null, string sort = null, int pageNumber = 1, int pageSize = 15)
        {
            //return _context.Suppliers;
            Expression<Func<Supplier, bool>> searchName;

            if (string.IsNullOrEmpty(name))
            {
                searchName = d => true;
            }
            else
            {
                searchName = d => d.Name.Contains(name) || d.GSTNumber.Contains(name);
            }
            var query = _context.Suppliers.Where(d=>d.Deleted==false).Where(searchName);
            switch (sort)
            {
                case "name":
                    query = query.OrderBy(x => x.Name);
                    break;
                case "nameDesc":
                    query = query.OrderByDescending(x => x.Name);
                    break;
                case "dateDesc":
                    query = query.OrderByDescending(x => x.ModifiedDate);
                    break;
                case "date":
                    query = query.OrderBy(x => x.ModifiedDate);
                    break;
                case "email":
                    query = query.OrderBy(x => x.ContactEmail);
                    break;
                case "emailDesc":
                    query = query.OrderByDescending(x => x.ContactEmail);
                    break;
                default:
                    break;
            }
            var entities= query
                .Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .Include(d => d.Products)
                .ToList();
            return _mapper.Map<IEnumerable<SupplierModel>>(entities);
        }
        [HttpGet]
        
        [Route("total")]
        public int GetSupplierTotal(string name = null)
        {
            Expression<Func<Supplier, bool>> searchName;

            if (string.IsNullOrEmpty(name))
            {
                searchName = d => true;
            }
            else
            {
                searchName = d => d.Name.Contains(name) || d.GSTNumber.Contains(name);
            }
            return _context.Suppliers.Where(d => d.Deleted == false).Where(searchName).Count();
        }
        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                _logger.LogWarning($"not found supplier id {id}");
                return NotFound();
            }

            return Ok(_mapper.Map<SupplierModel>(supplier));
        }

        // PUT: api/Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier([FromRoute] int id, [FromBody] SupplierModel model)
        {
            var entity = _context.Suppliers.First(d => d.Id == model.Id);

            if (entity is null)
            {
                return BadRequest();
            }
            _mapper.Map(model, entity);
            entity.ModifiedDate = DateTime.UtcNow;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
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

        // POST: api/Suppliers
        [HttpPost]
        public async Task<IActionResult> PostSupplier([FromBody] SupplierModel model)
        {
            var entity = _mapper.Map<Supplier>(model);
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplier", new { id = entity.Id }, entity);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                _logger.LogWarning($"Not found supplier id {id} when delete it.");
                return NotFound();
            }
            supplier.Deleted = true;
            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();

            return Ok(supplier);
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}