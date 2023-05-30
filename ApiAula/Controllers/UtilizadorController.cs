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
            if (String.IsNullOrEmpty(Utilizador.Nome) || Utilizador.Nome.Length <2)
                return BadRequest("Nome invalido!");

  

            _context.Alunos.Add(Utilizador);
            await _context.SaveChangesAsync();
            return Utilizador.Id;
        }


        
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            Utilizador Utilizador;
            Utilizador = await _context.utilizadors.FirstOrDefaultAsync(p => p.Id == id);

            //_context.NOME_DA_TABELA_NO_BANCO_DE_DADOS
            //Se nao for encontrado -> sinaliza elemento nao encontrado
            if (Utilizador == null)
                return NotFound("utilizador excluído com sucesso。");

            //se for remove o elemento
            _context.utilizadors.Remove(Utilizador);
            await _context.SaveChangesAsync();

            return NotFound("utilizador não existe。");
        }
        
        [HttpGet("alfabeto/{strBegin}")]
        public async Task<ActionResult<List<Utilizador>>> GetByAlfabeto(string strBegin)
        {
            List<Utilizador> listUtilizadors;
            listUtilizadors = 
                await _context.utilizadors.AsQueryable()
                .Where( a => a.Nome.StartsWith(strBegin) ).ToListAsync();
            return listUtilizadors;
        }

        [HttpPut]
        public async Task<ActionResult> Atualizar(Utilizador produto)
        {
            _context.Attach(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NotFound("invalido");
        }
    }
}
