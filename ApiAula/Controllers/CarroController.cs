using ApiAula.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiAula.Controllers
{
    [ApiController]

    [Route("teste/Carro")]

    public class CarroController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarroController(ApplicationDbContext context)
        {
            _context = context;
        }

       

        //Cadastro
        [HttpPost]
        public async Task<ActionResult<int>> Post(Carro produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto.Id;
        }

        //Leitura todos Elementos da Tabela do Banco
        [HttpGet]
        public async Task<ActionResult<List<Carro>>> GetProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        //Leitura de um Elmento do banco dados pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Carro>> GetProdutos(int id)
        {
            Carro produto;
            produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);
            if (produto == null)
                return NotFound();

            return produto;
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            Carro produto;
            produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            //Se nao for encontrado -> sinaliza elemento nao encontrado
            if (produto == null)
                return NotFound("excluído com sucesso。");

            //se for remove o elemento
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NotFound("carro não existe。");
        }

        //Atualizar Conteudo no SGBD
        [HttpPut]
        public async Task<ActionResult> Atualizar(Carro produto)
        {
            _context.Attach(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
