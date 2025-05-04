// Models/Cliente.cs
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotel.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }

        public string Cedula { get; set; }

        public string TipoCedula { get; set; }

        public string NombreCliente { get; set; }

        public string Telefono { get; set; }

        public string DireccionCliente { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int Restablecer { get; set; }

        public int RoleID { get; set; }
    }
}
