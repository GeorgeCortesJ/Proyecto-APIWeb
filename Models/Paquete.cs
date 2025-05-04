// Models/Paquete.cs
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotel.Models
{
    public class Paquete
    {
        [Key]
        public int ID { get; set; }

        public string TipoPaquete { get; set; }

        public int Costo { get; set; }

        public double Prima { get; set; }

        public int CantidadCuotas { get; set; }
    }
}
