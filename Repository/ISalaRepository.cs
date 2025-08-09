using Banana.Booking.Api.Models;

namespace Banana.Booking.Api.Repository
{
    public interface ISalaRepository
    {
        Task AddSala(SalaDeReuniao sala);
        Task UpdateSala(SalaDeReuniao value, int id);
        Task RemoveSala(int id);
        Task<SalaDeReuniao> GetSala(int salaId);
        Task<IEnumerable<SalaDeReuniao>> GetSalas();
        
    }
}
