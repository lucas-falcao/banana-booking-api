using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Banana.Booking.Api.Models
{
    public class Reserva
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int SalaDeReuniaoId { get; set; }

        [ForeignKey("SalaDeReuniaoId")]
        public virtual SalaDeReuniao? SalaDeReuniao { get; set; }

        // Se der tempo para auth será int. Se não, será string
        [Required]
        public string Responsavel { get; set; } = string.Empty;

        public bool? Cafe { get; set; } // Informar quantidade
        [Required]
        public int QuantidadeDePessoas { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;


    }
}
