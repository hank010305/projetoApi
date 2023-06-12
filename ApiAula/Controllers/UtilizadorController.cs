using ApiAula.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAula.Controllers
{
    [ApiController]

    [Route("Utilizador")]

    public class UtilizadorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UtilizadorController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Utilizador Utilizador)
        {
            _context.utilizadors.Add(Utilizador);
            await _context.SaveChangesAsync();
            return Utilizador.Id;
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Utilizador utilizador;
            utilizador = await _context.utilizadors.FirstOrDefaultAsync(p => p.Id == id);

            // Se o usuário não for encontrado, retorne o resultado não encontrado
            if (utilizador == null)
                return NotFound("O utilizador não existe.");

            // Se o usuário for encontrado, exclua-o
            _context.utilizadors.Remove(utilizador);
            await _context.SaveChangesAsync();

            return Ok("O utilizador foi excluído com sucesso.");
        }

        [HttpGet]
        public async Task<ActionResult<List<Utilizador>>> GetProdutos()
        {
            return await _context.utilizadors.ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult> Atualizar(Utilizador produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok("O utilizador foi atualizado com sucesso.");
        }
    }
}
