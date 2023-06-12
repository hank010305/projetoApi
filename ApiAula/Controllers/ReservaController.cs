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
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Reserva reserva;
            reserva = await _context.Reserva.FirstOrDefaultAsync(p => p.Id == id);

            //Se o veículo não for encontrado, retorne o resultado não encontrado
            if (reserva == null)
                return NotFound(" não existe.");

            // Se um veículo for encontrado, exclua-o
            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return Ok(" foi excluído com sucesso.");
        }

        //Atualizar Conteudo no SGBD
        [HttpPut]
        public async Task<ActionResult> Atualizar(Reserva reserva)
        {
            _context.Attach(reserva).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("Atualizado com sucesso.");
        }
    }
}
