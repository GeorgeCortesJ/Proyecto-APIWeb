
//Librerias para utilizar JWT
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

//Referencia modelo
using ProyectoHotel.Models;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ProyectoHotel.Services
{
    public class AutorizacionServices : IAutorizacionServices
    {
        //Variable permite utilizar el archivo appsettings.json
        private readonly IConfiguration _configuration;

        //Variable para utilizar las funciones del  ORM
        private readonly DbContextBeachHotel _context;

        /// <summary>
        /// Constructor con parámetros
        /// </summary>
        /// <param name="configuration">Referencia para manejar
        /// la variable configuración</param>
        /// <param name="context">
        /// Referencia para el manejo del ORM
        /// </param>
        public AutorizacionServices(IConfiguration configuration,
            DbContextBeachHotel context)
        {
            _configuration = configuration;
            _context = context;
        }

        public async Task<AutorizacionResponse> DevolverToken(Cliente autorizacion)
        {
            //Se identifica al usuario que está solicitando la autorización
            //Validando su email y password
            var temp = await _context.Clientes.FirstOrDefaultAsync(u => 
            u.Email.Equals(autorizacion.Email)  && 
            u.Password.Equals(autorizacion.Password));

            //Si no hay datos
            if (temp == null)
            {
                //En caso que sea null se retorna una autorización en blanco..
                return await Task.FromResult<AutorizacionResponse>(null);
            }

            string tokenCreado = GenerarToken(autorizacion.Email);

            return new AutorizacionResponse()
            {
                Token = tokenCreado,
                Resultado = true,
                Msj = "OK"
            };

        }

        private string GenerarToken(string pEmail)
        {
            //Se realiza lectura de la key almacenada dentro del archivo configuración JSON
            var key = _configuration.GetValue<string>("JwtSettings:Key");

            //Se convierte la key en un vector de bytes
            var keyBytes = Encoding.ASCII.GetBytes(key);

            //Se instancia la identidad que realiza el reclamo para la autorización
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, pEmail));

            //Se instancia las credenciales del token
            var credencialesToken = new SigningCredentials(
                new SymmetricSecurityKey(keyBytes),
                SecurityAlgorithms.HmacSha256Signature);

            //se instancia el descriptor del token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = credencialesToken
            };

            //se instancia el tokenHandler para construir el token
            var tokenHandler = new JwtSecurityTokenHandler();
            //Se crea el token
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            //Se escribe el token
            var tokenCreado = tokenHandler.WriteToken(tokenConfig);

            //se retorna el token
            return tokenCreado;
        }


    } //Cierre class
} //Cierre namespaces
