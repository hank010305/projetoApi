using ApiAula.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReservaController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post(Reserva reserva)
        {
            _context.Reserva.Add(reserva);
            await _context.SaveChangesAsync();
            return reserva.Id;
        }

        //Leitura todos Elementos da Tabela do Banco
        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> GetReserva()
        {
            return await _context.Reserva.ToListAsync();
        }

        //Leitura de um Elmento do banco dados pelo ID
    }
}
