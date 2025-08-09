using Banana.Booking.Api.Models;

namespace Banana.Booking.Api.Services
{
    public interface IReservaService
    {
        Task<Reserva> AddReserva(Reserva reserva);
        Task<Reserva> UpdateReserva(Reserva reserva, int id);
        Task RemoveReserva(int id);
        Task<Reserva> GetReserva(int reservaId);
        Task<IEnumerable<Reserva>> GetReservas();
    }
}
