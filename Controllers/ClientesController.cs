// Controllers/ClientesController.cs
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoHotel.Models;


namespace ProyectoHotel.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DbContextBeachHotel _context;

        public ClientesController(DbContextBeachHotel appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet("List")]
        public IEnumerable<Cliente> List()
        {
            return _context.Clientes.ToList();
        }

        [HttpGet("SearchId")]
        public Cliente Get(int id)
        {
            return this._context.Clientes.Find(id);
        }
        [HttpPost("Insert")]
        public IActionResult Post(Cliente cliente)
        {
            try
            {
                this._context.Clientes.Add(cliente);
                this._context.SaveChanges();

                return Ok("Cliente agregado correctamente");
            }
            catch (Exception ex)
            {
                return NotFound("Error " + ex.Message);
            }
        }
        [HttpPut("Update")]
        public IActionResult Put(Cliente cliente)
        {
            try
            {
                _context.Clientes.Update(cliente);
                _context.SaveChanges();

                return Ok("El cliente fue actualizado correctamente");
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
                var temp = this._context.Clientes.Find(id);
                this._context.Clientes.Remove(temp);
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
