using Banana.Booking.Api.Data;
using Banana.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Banana.Booking.Api.Repository
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly AppDbContext _db;

        public ReservaRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddReserva(Reserva reserva)
        {
            await _db.Reservas.AddAsync(reserva);
            await _db.SaveChangesAsync();
        }

        public async Task<Reserva> GetReserva(int reservaId)
        {
            return await _db.Reservas.Where(r => r.Id == reservaId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reserva>> GetReservas()
        {
            return await _db.Reservas.ToListAsync();
        }

        public async Task RemoveReserva(int id)
        {
            await _db.Reservas.Where(r => r.Id  == id).ExecuteDeleteAsync();
        }

        public async Task UpdateReserva(Reserva reserva, int reservaId)
        {
            await _db.Reservas.Where(reserva => reserva.Id == reservaId)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(r => r.HoraInicio, reserva.HoraInicio)
                .SetProperty(r => r.HoraFim, reserva.HoraFim)
                .SetProperty(r => r.QuantidadeDePessoas, reserva.QuantidadeDePessoas)
                //.SetProperty(r => r.SalaDeReuniao, reserva.SalaDeReuniao)
                .SetProperty(r => r.SalaDeReuniaoId, reserva.SalaDeReuniaoId)
                .SetProperty(r => r.Responsavel, reserva.Responsavel)
                .SetProperty(r => r.Cafe, reserva.Cafe));
            await _db.SaveChangesAsync();
        }
    }
}
