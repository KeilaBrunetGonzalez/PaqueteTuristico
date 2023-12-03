using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
namespace PaqueteTuristico.Controllers
{
    public class UserController : Controller
    {
        private readonly conocubaContext _context;

        public UserController(conocubaContext context)
        {
            _context = context;
        }

        [HttpPost("api/register")]
        public IActionResult Register(User user)
        {
            // Crea un hash y una sal para la contraseña
            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.PasswordHash));
             user.PasswordSalt = hmac.Key;


            // Guarda el usuario en la base de datos
            _context.UserSet.Add(user);
            _context.SaveChanges();

            return Ok();
        }

       /* [HttpPost("api/login")]
        public IActionResult Login(string username, string password)
        {
            // Busca al usuario en la base de datos
            var user = _context.UserSet.SingleOrDefault(u => u.Name == username);
            if (user == null)
            {
                return Unauthorized("Usuario no válido");
            }

            // Verifica la contraseña
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Contraseña no válida");
                }
            }

            // Si la contraseña es correcta, devuelve un token de acceso (aquí deberías generar y devolver un token JWT o similar)

            return Ok();
        }*/
    }
}