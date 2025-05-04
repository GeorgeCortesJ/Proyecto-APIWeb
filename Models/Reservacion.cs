// Models/Reservacion.cs
using System.ComponentModel.DataAnnotations;

namespace ProyectoHotel.Models
{
    public class Reservacion
    {
        [Key]
        public int ID { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public int CantidadPersonas { get; set; }
        public string MetodoPago { get; set; }
        public string? NumeroCheque { get; set; }
        public string? BancoCheque { get; set; }
        public double Subtotal { get; set; }
        public double Descuento { get; set; }
        public double MontoTotalColones { get; set; }
        public double MontoTotalDolares { get; set; }
        public double Prima { get; set; }
        public double Cuota { get; set; }
        public int PaqueteID { get; set; }
        public int ClienteID { get; set; }


        public string EstadoPago
        {
            get
            {
                if ((MetodoPago == "Cheque") || (MetodoPago == "Tarjeta"))
                {
                    return "Confirmado";
                }
                else
                {
                    return "Pendiente";
                }
            }
        }

        public int CantidadNoches
        {
            get
            {
                TimeSpan duracion = FechaSalida.Date - FechaEntrada.Date;
                return duracion.Days;
            }
        }


    }
}
