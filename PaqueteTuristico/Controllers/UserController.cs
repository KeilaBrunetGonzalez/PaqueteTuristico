using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Register([FromBody]User user)
        {
            if(await userManager.FindByEmailAsync(user.Email) == null)
            {
                var tempuser = new IdentityUser { UserName= user.UserName , Email = user.Email};
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
                var claims = new[]
                {
               new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
               new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
               new Claim("Id", user.Id),

            };
                // Obtener la llave privada encriptada
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));

                // Se establece la llave de la firma y el metodo de seguridad
                var sining = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Creacion del token
                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: sining
                    );
                //el token se devuelve en formato de string
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
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
            return Unauthorized();
        }

    }
}