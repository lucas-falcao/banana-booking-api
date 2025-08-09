using Banana.Booking.Api.Models;
using Banana.Booking.Api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Banana.Booking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;
        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }
        // GET: api/<SalasController>
        [HttpGet]
        public async Task<IEnumerable<SalaDeReuniao>> Get()
        {
            return await _salaService.GetSalas();
        }

        // GET api/<SalasController>/5
        [HttpGet("{id}")]
        public async Task<SalaDeReuniao> Get(int id)
        {
            return await _salaService.GetSala(id);
        }

        // POST api/<SalasController>
        [HttpPost]
        public async Task Post([FromBody] SalaDeReuniao sala)
        {
            await _salaService.AddSala(sala);
        }

        // PUT api/<SalasController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] SalaDeReuniao sala)
        {
            await _salaService.UpdateSala(sala, id);
        }

        // DELETE api/<SalasController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _salaService.RemoveSala(id);
        }
    }
}
