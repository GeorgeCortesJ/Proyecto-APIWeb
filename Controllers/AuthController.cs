using Microsoft.AspNetCore.Mvc;
using ProyectoHotel.Models;
using ProyectoHotel.Services;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProyectoHotel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        //Variable para manejar la referencia del  ORM
        private readonly DbContextBeachHotel _contexto = null;
        //Variable para manejar el servicio de autorización
        private readonly IAutorizacionServices _autorizacionServices;

        public AuthController(DbContextBeachHotel pContext,
              IAutorizacionServices autorizacionServices)
        {
            _contexto = pContext;//se asigna la referencias
            _autorizacionServices = autorizacionServices;
        }

        [HttpPost]
        [Route("Autenticar")]
        public async Task<IActionResult> Autenticar(Cliente autenticar)
        {  //se utiliza el servicio para la autorización el usuario
            var autorizado = await _autorizacionServices.DevolverToken(autenticar);
            //en caso que no esté autorizado
            if (autorizado == null)
            {  //se retorna no autorizado
                return Unauthorized();
            }
            else
            {  //se retorna un 200 ok con la información
                return Ok(autorizado);
            }
        }
    }
}
