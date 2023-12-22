using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PaqueteTuristico.Data;
using PaqueteTuristico.Models;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly UserManager<IdentityUser> userManager;

    public EmailController( UserManager<IdentityUser> user)
    {
        userManager = user;
    }

    [HttpPost]
    public async Task<IActionResult> EnviarCorreo([FromBody] Email emailRequest)
    {
        try
        {
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("assigment34@gmail.com", "glat argw gndr kepr");
                smtpClient.EnableSsl = true;

                smtpClient.Port = 587;

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("assigment34@gmail.com"),
                    Subject = emailRequest.Subject,
                    Body = $"Hola {emailRequest.Name},\n\n{emailRequest.Body}",
                };

                mailMessage.To.Add(new MailAddress(emailRequest.To));

                await smtpClient.SendMailAsync(mailMessage);
            }

            return Ok(new { success = true, message = "Correo enviado con éxito" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = "Error al enviar el correo", error = ex.Message });
        }
    }

}
