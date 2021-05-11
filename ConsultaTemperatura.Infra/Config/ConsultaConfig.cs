using ConsultaTemperatura.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ConsultaTemperatura.Infra.Config
{
    public class ConsultaConfig : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasIndex(c => c.Cidade).IsUnique();

            builder.Property(c => c.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(c => c.TemperaturaAtual).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(c => c.TemperaturaMaxima).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(c => c.TemperaturaMinima).HasColumnType("decimal(8,2)").IsRequired();
            builder.Property(c => c.UltimaConsulta).IsRequired();
        }
    }
}
