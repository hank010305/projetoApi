using ApiAula.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAula.Controllers
{
    [ApiController]

    [Route("api/teste/Utilizador")]

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

            // 如果未找到用户，则返回找不到的结果
            if (utilizador == null)
                return NotFound("O utilizador não existe.");

            // 如果找到用户，则删除它
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
