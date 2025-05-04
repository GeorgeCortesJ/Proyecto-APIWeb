// Controllers/PaquetesController.cs
using ProyectoHotel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProyectoHotel.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PaquetesController : Controller
    {
        private readonly DbContextBeachHotel _context;

        public PaquetesController(DbContextBeachHotel appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet("List")]
        public IEnumerable<Paquete> GetPaquete()
        {
            return _context.Paquetes.ToList();
        }

        [HttpGet("SearchId")]
        public Paquete getPaquete(int id)
        {
            return this._context.Paquetes.Find(id);
        }
    }
}
