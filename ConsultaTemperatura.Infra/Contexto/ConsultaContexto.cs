using ConsultaTemperatura.Dominio.Entidade;
using ConsultaTemperatura.Infra.Config;
using Microsoft.EntityFrameworkCore;

namespace ConsultaTemperatura.Infra.Contexto
{
    public class ConsultaContexto : DbContext
    {
        public DbSet<Consulta> Consulta { get; set; }
        public ConsultaContexto(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConsultaConfig());
            base.OnModelCreating(modelBuilder);
        }
    }
}
