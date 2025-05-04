// Controllers/ReservacionesController.cs

using ProyectoHotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProyectoHotel.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly DbContextBeachHotel _context;

        public ReservasController(DbContextBeachHotel appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet("List")]
        public IEnumerable<Reservacion> Get()
        {
            return _context.Reservas.ToList();
        }

        [HttpGet("SearchId")]
        public Reservacion Get(int id)
        {
            return this._context.Reservas.Find(id);
        }

        [HttpPost("Insert")]
        public IActionResult Post(Reservacion reserva)
        {
            try
            {
                this._context.Reservas.Add(reserva);
                this._context.SaveChanges();

                return Ok("Reserva agregada correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        [HttpPut("Update")]
        public IActionResult Put(Reservacion reserva)
        {
            try
            {
                _context.Reservas.Update(reserva);
                _context.SaveChanges();

                return Ok("La reserva se actualizo correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                var temp = this._context.Reservas.Find(id);
                this._context.Reservas.Remove(temp);
                this._context.SaveChanges();

                return Ok("El cliente con ID: " + id + " fue eliminado correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
    }
}
