﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Repositories.Context.Entities;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILogger<AuthController> _logger;
        private SignInManager<ApplicationUser> _signInMgr;
        private UserManager<ApplicationUser> _userMgr;
        private IPasswordHasher<ApplicationUser> _hasher;
        private IConfigurationRoot _config;
        private readonly ClaimsPrincipal _caller;

        public AuthController(
          SignInManager<ApplicationUser> signInMgr,
          UserManager<ApplicationUser> userMgr,
          IPasswordHasher<ApplicationUser> hasher,
          ILogger<AuthController> logger,
          IConfigurationRoot config,
          ClaimsPrincipal caller
          )
        {
            _signInMgr = signInMgr;
            _logger = logger;
            _userMgr = userMgr;
            _hasher = hasher;
            _config = config;
            _caller = caller;
        }

        [HttpPost("token")]
        public async Task<IActionResult> CreateToken([FromBody] CredentialModel model)
        {
            try
            {
                var user = await _userMgr.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result = await _signInMgr.PasswordSignInAsync(model.UserName, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        var userClaims = await _userMgr.GetClaimsAsync(user);
                        var userRoles =await _userMgr.GetRolesAsync(user);
                        var claims = new[]
                        {
                          new Claim(JwtRegisteredClaimNames.Sub, model.UserName),
                          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                          new Claim(JwtRegisteredClaimNames.Email, user.Email)
                        }.Union(userClaims);

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("FooBarQuuxIsTheStandardTypeOfStringWeUse12345"));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                          issuer: _config["Tokens:Issuer"],
                          audience: _config["Tokens:Audience"],
                          claims: claims,
                          expires: DateTime.UtcNow.AddHours(20),
                          signingCredentials: creds
                          );

                        return Ok(new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            roles = userRoles,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception thrown while creating JWT: {ex}");
            }

            return BadRequest("Failed to generate token");
        }
        [HttpGet]
        [Route("currentuser")]
        public ActionResult getCurrentUser()
        {
            if (_caller.Claims.Count() == 0)
                return BadRequest();
            return new JsonResult(_caller.Claims.Where(d => d.Type.Contains( JwtRegisteredClaimNames.Email)).Select(
                c => new { c.Type, c.Value }));

        }
    }
}
