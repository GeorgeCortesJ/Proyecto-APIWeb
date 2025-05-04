using System;
using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;

namespace ProyectoHotel.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RolesController : Controller
    {
        private readonly DbContextBeachHotel _context;

        public RolesController(DbContextBeachHotel appDbContext)
        {
            _context = appDbContext;
        }

        [HttpGet]
        public IEnumerable<Roles> GetRoles()
        {
            return _context.Roles.ToList();
        }

        [HttpGet("{id}")]
        public Roles getRoles(int id)
        {
            return this._context.Roles.Find(id);
        }

    }
}