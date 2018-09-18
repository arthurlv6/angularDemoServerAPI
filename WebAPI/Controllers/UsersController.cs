using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "SystemPolicy")]
    //[Authorize(Roles = "Settings")]
    public class UsersController : BaseController
    {
        private ILogger<UsersController> _logger;
        private readonly IUserService _userService;
        
        public UsersController(
            IMapper mapper,
            ILogger<UsersController> logger,
            IUserService userService,
            IMediator mediator,
            IServiceProvider serviceProvider) : base( mapper, mediator)
        {
            _logger = logger;
            _userService = userService;
        }
        /*
        // GET: api/Users
        [HttpGet]
        
        public IEnumerable<User> Get()
        {
            
            var users= _context.Users.Select(d => new User()
            {
                Id = d.Id,
                Name = d.Name,
                Title = d.JobTitle,
                Email=d.Email,
                Phone=d.PhoneNumber
            }).ToList();
            foreach (var user in users)
            {
                user.Roles= _context.UserRoles.Where(d => d.UserId == user.Id).Select(d=> new Role()
                {
                    Id=d.RoleId,
                    Name= _context.Roles.FirstOrDefault(r => r.Id == d.RoleId).Name
                }).ToList();
            }
            return users;
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Users
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute]string id, [FromBody] UserIdAndValue user)
        {
            if (_context.Users.FirstOrDefault(d => d.Id == id) == null)
                return NotFound();
            try
            {
                var list = _userService.Operations();
                var operation = list.FirstOrDefault(d => d.IsMatch(user.Type));
                if (operation == null) return BadRequest("Type doesn't exist.");
                await operation.UpdateUser(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }

}
