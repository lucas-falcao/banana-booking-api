using Banana.Booking.Api.Models;
using Banana.Booking.Api.Repository;

namespace Banana.Booking.Api.Services
{
    public class ReservaService : IReservaService
    {
        private readonly IReservaRepository _reservaRepository;
        private readonly ISalaService _salaService;
        public ReservaService(IReservaRepository reservaRepository, ISalaService salaService) 
        {
            _reservaRepository = reservaRepository;
            _salaService =  salaService;
    }
        public async Task<Reserva> AddReserva(Reserva reserva)
        {
            bool horarioValido = await ValidaHorario(reserva);
            if (horarioValido)
            {
                await _reservaRepository.AddReserva(reserva);
                return reserva;
            }

            return null;
        }

        public async Task<Reserva> GetReserva(int reservaId)
        {
            return await _reservaRepository.GetReserva(reservaId);
        }

        public async Task<IEnumerable<Reserva>> GetReservas()
        {
            return await _reservaRepository.GetReservas();
        }

        public async Task RemoveReserva(int id)
        {
             await _reservaRepository.RemoveReserva(id);
        }

        public async Task<Reserva> UpdateReserva(Reserva reserva, int id)
        {
            bool horarioValido = await ValidaHorario(reserva);
            if (horarioValido)
            {
                await _reservaRepository.UpdateReserva(reserva, id);
                return reserva;
            }
           
            return null;
        }

        public async Task<bool> ValidaHorario(Reserva reserva)
        {
            var reservas = await GetReservas();
            
            bool choqueHorario = reservas.Any(r => reserva.SalaDeReuniaoId == r.SalaDeReuniaoId && r.Id != reserva.Id && (reserva.StartTime <= r.StartTime && reserva.EndTime >= r.EndTime));     // Apenas o começo.
            return !choqueHorario;
        }
    }
}
