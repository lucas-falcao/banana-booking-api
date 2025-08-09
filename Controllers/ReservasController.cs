using Banana.Booking.Api.Models;
using Banana.Booking.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Banana.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservasController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }
        // GET: api/<ReservasController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var result = await _reservaService.GetReservas();
            return Ok(result);
        }

        // GET api/<ReservasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Reserva? result = await _reservaService.GetReserva(id);
            return Ok(result);
        }

        // POST api/<ReservasController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reserva reserva)
        {
            Reserva? result = await _reservaService.AddReserva(reserva);
            return Ok(result);
        }

        // PUT api/<ReservasController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Reserva reserva)
        {
            Reserva? result = await _reservaService.UpdateReserva(reserva, id);
            return Ok(result);
        }

        // DELETE api/<ReservasController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _reservaService.RemoveReserva(id);
            return Ok();
        }
    }
}
