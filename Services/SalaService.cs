using Banana.Booking.Api.Models;
using Banana.Booking.Api.Repository;

namespace Banana.Booking.Api.Services
{
    public class SalaService : ISalaService
    {
        private readonly ISalaRepository _salaRepository;

        public SalaService(ISalaRepository SalaRepository) 
        {
            _salaRepository = SalaRepository;
        }
        public async Task AddSala(SalaDeReuniao sala)
        {
            
            await _salaRepository.AddSala(sala);
        }

        public async Task<SalaDeReuniao> GetSala(int salaId)
        {
            return await _salaRepository.GetSala(salaId);
        }

        public async Task<IEnumerable<SalaDeReuniao>> GetSalas()
        {
            return await _salaRepository.GetSalas();
        }

        public async Task RemoveSala(int id)
        {
             await _salaRepository.RemoveSala(id);
        }

        public async Task UpdateSala(SalaDeReuniao sala, int id)
        {
            await _salaRepository.UpdateSala(sala, id);
        }

    }
}
