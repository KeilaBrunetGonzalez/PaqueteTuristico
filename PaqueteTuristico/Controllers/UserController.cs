using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Dtos;
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
        private readonly UserManager<UserApp> userManager;

        public UserController(IConfiguration config, conocubaContext context, UserManager<UserApp> user)
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
                var tempuser = new UserApp { UserName = user.UserName, Email = user.Email };
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

        [HttpPost("login/{userName}/{password}")]
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
                    new Claim("UserId", user.Id)
                    
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
        [HttpDelete("{userid}")]
        [Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> DeleteUser(string userid)
        {
           var user = await userManager.FindByIdAsync(userid);
            if(user != null)
            {
                await userManager.DeleteAsync(user);
                return Ok("El usuario ha sido eliminado");
            }
            else { 
                return BadRequest("El usuario a eliminar no se encuentra registrado");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsersWithRol()
        {
            var users = await userManager.Users.ToListAsync();

            if (users != null)
            {
                var usersWithRol = new List<object>();
                foreach (var user in users)
                {
                    var roles = await userManager.GetRolesAsync(user);

                    var userWithRole = new
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        Email = user.Email,
                        Roles = roles
                    };

                    usersWithRol.Add(userWithRole);
                }
                return Ok(usersWithRol);
            }

            return NotFound();
        }

    }
}