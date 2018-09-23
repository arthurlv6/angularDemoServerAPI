using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Filters;
using AutoMapper;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using MediatR;
using UseCases.Requests;
using Models;
using UseCases;
using Repositories.Contract;
using Microsoft.AspNetCore.Http;
using Repositories.Entities.Exceptions;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    //[Authorize]
    public class SuppliersController : BaseController
    {
        public SuppliersController(
            IMapper mapper,
            IMediator mediator
            ) : base(mapper, mediator)
        {
        }
        // GET: api/Suppliers
        [HttpGet]
        public async Task<IList<SupplierModel>> GetSuppliers(string name = null, string sort = null, int pageNumber = 1, int pageSize = 15)
        {
            var list=_mediator.Send(new SupplierGetRequest() { Name=name,Sort=sort,PageNumber=pageNumber,PageSize=pageSize});
            return await list;
        }
        
        [HttpGet]
        [Route("total")]
        public async Task<int> GetSupplierTotal(string name = null)
        {
            return await _mediator.Send(new SupplierTotalRequest() { Name = name});
        }
        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplier([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var model = await _mediator.Send(new SupplierGetSingleRequest() { Id = id });
                return Ok(model);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        // PUT: api/Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier([FromRoute] int id, [FromBody] SupplierModel model)
        {
            model.Id = id;
            try
            {
                await _mediator.Send(new SupplierUpdateRequest() { SupplierModel = model });
            }
            catch(SaveException ex)
            {
                throw ex;
            }
            catch (ValidationExistException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                throw new Exception("Internal error.");
            }
            return NoContent();
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<IActionResult> PostSupplier([FromBody] SupplierModel model)
        {
            model.Id = 0;

            try
            {
               var createdModel= await _mediator.Send(new SupplierInsertRequest() { SupplierModel = model });
                return CreatedAtAction("GetSupplier", new { id = createdModel.Id }, createdModel);
            }
            catch (SaveException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier([FromRoute] int id)
        {
            try
            {
                var createdModel = await _mediator.Send(new SupplierDeleteRequest() { Id = id });
            }
            catch (ValidationExistException)
            {
                return NotFound();
            }
            catch (SaveException ex)
            {
                throw ex;
            }
            return Ok();
        }
        
    }
}