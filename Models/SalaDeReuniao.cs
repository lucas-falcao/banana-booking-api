using System.ComponentModel.DataAnnotations;

namespace Banana.Booking.Api.Models
{
    public class SalaDeReuniao
    {
        [Key]
        public int Id { get; set; }
       
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public int Capacidade { get; set; }
        public string Local { get; set; } = string.Empty;

        public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
