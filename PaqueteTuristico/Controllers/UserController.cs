﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using PaqueteTuristico.Utils;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace PaqueteTuristico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly conocubaContext _context;
        private readonly IConfiguration configuration;
        private readonly UserManager<IdentityUser> userManager;

        public UserController(IConfiguration config, conocubaContext context, UserManager<IdentityUser> user)
        {
            _context = context;
            configuration = config;
            userManager = user;

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                var tempuser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                var result = await userManager.CreateAsync(tempuser, user.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(tempuser, "User");
                    _context.SaveChanges();

                } else
                {
                    return BadRequest(result);
                }

                return Ok("User registered");

            }
            return Unauthorized();
        }

        [HttpPost("api/login/{userName}/{password}")]
        public async Task<IActionResult> Login(string userName, string password)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (user != null && await userManager.CheckPasswordAsync(user, password))
            {
                var jwt = configuration.GetSection("Jwt").Get<Jwt>();
                var roles = await userManager.GetRolesAsync(user);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email),
                    
                }
                  .Concat(roles.Select(role => new Claim(ClaimTypes.Role, role)))
                  .ToArray();

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var sining = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(1200),
                    signingCredentials: sining
                );
                
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                });
            }

            return Unauthorized();
        }
    }
}