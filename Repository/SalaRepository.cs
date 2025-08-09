using Banana.Booking.Api.Data;
using Banana.Booking.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Banana.Booking.Api.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly AppDbContext _db;

        public SalaRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task AddSala(SalaDeReuniao sala)
        {
            await _db.salasDeReuniao.AddAsync(sala);
            await _db.SaveChangesAsync();
        }

        public async Task<SalaDeReuniao> GetSala(int salaId)
        {
            return await _db.salasDeReuniao.Where(r => r.Id == salaId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SalaDeReuniao>> GetSalas()
        {
            return await _db.salasDeReuniao.ToListAsync();
        }

        public async Task RemoveSala(int id)
        {
            await _db.salasDeReuniao.Where(r => r.Id  == id).ExecuteDeleteAsync();
        }

        public async Task UpdateSala(SalaDeReuniao value, int SalaId)
        {
            await _db.salasDeReuniao.Where(sala => sala.Id == SalaId)
                .ExecuteUpdateAsync(setters => setters
                .SetProperty(s => s.Capacidade, value.Capacidade)
                .SetProperty(s => s.Name, value.Name)
                .SetProperty(s => s.Local, value.Local));
            await _db.SaveChangesAsync();
        }
    }
}
