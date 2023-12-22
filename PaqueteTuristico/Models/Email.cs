using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PaqueteTuristico.Models
{
    public class Email
    {

        [Required]
        public string To { get; set; } = string.Empty;

        [Required] public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public string Subject { get; set; } = "Reserva exitosa";

        [JsonIgnore]
        public string Body { get; set; } = "Nos complace informarte que tu reserva ha sido exitosa. Estamos emocionados de recibirte en nuestro destino en Cuba. Esperamos que disfrutes de unas vacaciones increíbles con nosotros.\n\n" +
           "¡Esperamos verte pronto!\n" +
           "Saludos cordiales,\n" +
           "El Equipo de Conoce Cuba" +
            "Si necesitas cancelar tu reserva, por favor haz clic en el siguiente enlace:\n\n" +
           "<a href=\"http://localhost:9000/#/\">Cancelar Reserva</a>";

    }

}
