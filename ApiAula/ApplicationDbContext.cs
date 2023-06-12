using ApiAula.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiAula
{
    public class ApplicationDbContext : DbContext
    {
        //Add DBSET
        //Ex: public DbSet<ClassType> DbSetName { get; set; }
        public DbSet<Carro> Produtos { get; set; }
        public DbSet<Utilizador> Alunos { get; set; }

        public DbSet<Utilizador> utilizadors { get; set; }
        public DbSet<Carro> Carros { get; set; }

        public DbSet<Reserva> Reserva { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }







    }
}
