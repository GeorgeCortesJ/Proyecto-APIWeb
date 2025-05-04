using System.ComponentModel.DataAnnotations;

namespace ProyectoHotel.Models
{
    public class Roles
    {
        [Key]
        public int ID { get; set; }

        public string NombreRol { get; set; }
    }
}
