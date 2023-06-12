using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace ApiAula.Entidades
{
    public class Reserva
    {
        public int Id { get; set; }
        public Carro Carro { get; set; }
        public Utilizador Utilizador { get; set; }
        public int CarroId { get; set; }
        public int UtilizadorId { get; set; }
    }
}
