using ProyectoHotel.Models;

namespace ProyectoHotel.Services
{
    public interface IAutorizacionServices
    {
        Task<AutorizacionResponse> DevolverToken(Cliente autorizacion);
    }
}
