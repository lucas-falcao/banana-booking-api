using Banana.Booking.Api.Models;

namespace Banana.Booking.Api.Repository
{
    public interface IReservaRepository
    {
        Task AddReserva(Reserva reserva);
        Task UpdateReserva(Reserva reserva, int id);
        Task RemoveReserva(int id);
        Task<Reserva> GetReserva(int reservaId);
        Task<IEnumerable<Reserva>> GetReservas();
        
    }
}
